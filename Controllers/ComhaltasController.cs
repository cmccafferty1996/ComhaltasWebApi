using ComhaltasWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ComhaltasWebApi.Controllers
{
    [RoutePrefix("api/comhaltas")]
    public class ComhaltasController : ApiController
    {
        private comhaltasTestEntities entities = new comhaltasTestEntities();

        [HttpGet]
        [Route("branches")]
        public HttpResponseMessage GetBranches()
        {
            List<Branch> branches = entities.Branches.ToList();
            List<BranchModel> result = new List<BranchModel>();

            if (branches.Count == 0) return Request.CreateResponse(HttpStatusCode.NotFound, "No Branches");

            for (int i = 0; i < branches.Count; i++)
            {
                result.Add(new BranchModel(branches[i].ID, branches[i].branch_name));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("age-groups")]
        public HttpResponseMessage GetAgeGroups()
        {
            List<Age_groups> ageGroups = entities.Age_groups.ToList();
            List<AgeGroupModel> result = new List<AgeGroupModel>();

            for (int i = 0; i < ageGroups.Count; i++)
            {
                result.Add(new AgeGroupModel(ageGroups[i].ID, ageGroups[i].category, ageGroups[i].age_group));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("competitions")]
        public HttpResponseMessage GetCompetitions(int age)
        {
            List<Competition> competitions = entities.Competitions
                .Where(comp => comp.age_group == age).ToList();
            List<CompetitionsModel> result = new List<CompetitionsModel>();

            for (int i = 0; i < competitions.Count; i++)
            {
                result.Add(new CompetitionsModel(competitions[i].ID, competitions[i].competition_number,
                    competitions[i].competition_name, competitions[i].age_group, competitions[i].competition_date));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("entrant")]
        public HttpResponseMessage GetEntrant(int id)
        {
            Entrant entrant = entities.Entrants.Find(id);
            if (entrant == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Error with id " + id);
            EntrantModel result = new EntrantModel(entrant.ID, entrant.entrant_name, entrant.branch, entrant.dob.Value);
            
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("entries")]
        public HttpResponseMessage GetEntries(int comp)
        {
            List<Entry> compEntries = entities.Entries
                .Where(entry => entry.competition == comp).ToList();
            List<EntryModel> result = new List<EntryModel>();

            for (int i = 0; i < compEntries.Count; i++)
            {
                int[] instrumentIds = new int[3] 
                    {compEntries[i].instrument1.GetValueOrDefault(), compEntries[i].instrument2.GetValueOrDefault(), compEntries[i].instrument3.GetValueOrDefault()};
                int[] entrantIds = new int[3]
                    {compEntries[i].entrant, compEntries[i].entrant2.GetValueOrDefault(), compEntries[i].entrant3.GetValueOrDefault()};
                
                result.Add(new EntryModel(compEntries[i].ID, compEntries[i].competition, compEntries[i].entrant,
                   getEntrantNamesAsList(entrantIds), getInstrumentNamesAsList(instrumentIds), compEntries[i].registered));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut]
        [Route("updateEntries")]
        public HttpResponseMessage UpdateEntries([FromBody] List<EntryModel> entries)
        {
            foreach (EntryModel entry in entries)
            {
                Entry compEntries = entities.Entries.Find(entry.id);

                if (compEntries != null)
                {
                    compEntries.registered = entry.registered;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Oh shite, error updating entry");
                }
            }
            entities.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Entries updated Success");
        }

        [HttpGet]
        [Route("results")]
        public HttpResponseMessage getResults(int comp)
        {
            Result compResults = entities.Results
                .SqlQuery("SELECT * FROM Results Where competition = @comp", new SqlParameter("@comp", comp))
                .FirstOrDefault();
            if (compResults == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Couldn't find results");

            var winners = new List<ResultsTableRow>();
            int recommended = compResults.recommended.GetValueOrDefault();

            if (compResults.first.ToString() != null)
            {
                int id = compResults.first;
                Entry firstEntry = entities.Entries.Find(id);
                int[] ids = new int[3] { firstEntry.entrant, firstEntry.entrant2.GetValueOrDefault(), firstEntry.entrant3.GetValueOrDefault() };
                int[] instumentIds = new int[3] { firstEntry.instrument1.GetValueOrDefault(), firstEntry.instrument2.GetValueOrDefault(), firstEntry.instrument3.GetValueOrDefault() };
                string name = getEntrantNamesAsList(ids);
                string instruments = getInstrumentNamesAsList(instumentIds);
                Entrant firstEntrant = entities.Entrants.Find(firstEntry.entrant);
                string branch = entities.Branches.Find(firstEntrant.branch).branch_name;
                winners.Add(new ResultsTableRow("1", name, instruments, branch));
            }

            if (compResults.second.GetValueOrDefault() != 0)
            {
                int id2 = compResults.second.Value;
                Entry secondEntry = entities.Entries.Find(id2);
                int[] ids = new int[3] { secondEntry.entrant, secondEntry.entrant2.GetValueOrDefault(), secondEntry.entrant3.GetValueOrDefault() };
                int[] instumentIds = new int[3] { secondEntry.instrument1.GetValueOrDefault(), secondEntry.instrument2.GetValueOrDefault(), secondEntry.instrument3.GetValueOrDefault() };
                string name2 = getEntrantNamesAsList(ids);
                string instruments2 = getInstrumentNamesAsList(instumentIds);
                Entrant firstEntrant = entities.Entrants.Find(secondEntry.entrant);
                string branch2 = entities.Branches.Find(firstEntrant.branch).branch_name;
                if (recommended == id2)
                {
                    winners.Add(new ResultsTableRow("2 R", name2, instruments2, branch2));
                } else
                {
                    winners.Add(new ResultsTableRow("2", name2, instruments2, branch2));
                }
            }

            if (compResults.third.GetValueOrDefault() != 0)
            {
                int id3 = compResults.third.Value;
                Entry thirdEntry = entities.Entries.Find(id3);
                int[] entrantIds = new int[3] { thirdEntry.entrant, thirdEntry.entrant2.GetValueOrDefault(), thirdEntry.entrant3.GetValueOrDefault() };
                int[] instumentIds = new int[3] { thirdEntry.instrument1.GetValueOrDefault(), thirdEntry.instrument2.GetValueOrDefault(), thirdEntry.instrument3.GetValueOrDefault() };
                string name3 = getEntrantNamesAsList(entrantIds);
                string instruments3 = getInstrumentNamesAsList(instumentIds);
                Entrant firstEntrant = entities.Entrants.Find(thirdEntry.entrant);
                string branch3 = entities.Branches.Find(firstEntrant.branch).branch_name;
                if (recommended == id3)
                {
                    winners.Add(new ResultsTableRow("3 R", name3, instruments3, branch3));
                }
                else
                {
                    winners.Add(new ResultsTableRow("3", name3, instruments3, branch3));
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, winners);
        }

        [HttpPut]
        [Route("update-results")]
        public HttpResponseMessage UpdateResults([FromBody] ResultModel results)
        {
            System.Diagnostics.Debug.WriteLine(results.third + " " + results.competition);

            Result compResult = entities.Results
                .SqlQuery("SELECT * FROM Results Where competition = @comp", new SqlParameter("@comp", results.competition))
                .FirstOrDefault();

            if (compResult != null)
            {
                compResult.first = (short) results.first;
                compResult.second = results.second.GetValueOrDefault() == 0 ? (short?)null : (short)results.second;
                compResult.third = results.third.GetValueOrDefault() == 0 ? (short?)null : (short)results.third;
                compResult.recommended = results.recommended.GetValueOrDefault() == 0 ? (short?) null : (short) results.recommended;
            }
            else
            {
                Result newResult = 
                    new Result(results. competition, results.first, results.second, results.third, results.recommended);

                entities.Results.Add(newResult);
            }
            entities.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Results saved Success");
        }

        [HttpGet]
        [Route("admin-user")]
        public HttpResponseMessage GetAdminUser(string username)
        {
            Admin_users admin = entities.Admin_users
                .SqlQuery("SELECT * FROM Admin_Users Where user_name = @name", new SqlParameter("@name", username))
                .FirstOrDefault();
            if (admin == null) return Request.CreateResponse(HttpStatusCode.NotFound, "User " + username + "not found");

            string password = admin.password;
            string start = password.Substring(0, 2);
            string end = password.Substring(password.Length - 2);
            string middle = password.Substring(2, password.Length - 4);
            string encryptedPassword = (end + middle + start);
            var passwordBytes = System.Text.Encoding.UTF8.GetBytes(encryptedPassword);

            return Request.CreateResponse(HttpStatusCode.OK, Convert.ToBase64String(passwordBytes));
        }

        [HttpGet]
        [Route("update-logon")]
        public HttpResponseMessage UpdateLogon(string username)
        {
            Admin_users admin = entities.Admin_users
                .SqlQuery("SELECT * FROM Admin_Users Where user_name = @name", new SqlParameter("@name", username))
                .FirstOrDefault();
            if (admin == null) return Request.CreateResponse(HttpStatusCode.NotFound, "User " + username + "not found");

            admin.last_logon = DateTime.Today;
            entities.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Logon saved success");
        }

        private string getInstrumentNamesAsList(int[] ids)
        {
            if (ids.Length == 0 || ids[0] == 0) return null;

            string instumentNames = "(";
            for (int y = 0; y < ids.Length; y++)
            {
                if (ids[y] != 0)
                {
                    string name = entities.Instruments.Find(ids[y]).instrument_name;
                    instumentNames += name;
                    if (y + 1 != ids.Length) instumentNames += "/";
                }
            }

            instumentNames += ")";
            return instumentNames;
        }

        private string getEntrantNamesAsList(int[] ids)
        {
            if (ids.Length == 0) return null;

            if (ids[1] == 0)
            {
                return entities.Entrants.Find(ids[0]).entrant_name;
            }

            if (ids[2] == 0)
            {
                string duetNames = 
                    entities.Entrants.Find(ids[0]).entrant_name + " & " + entities.Entrants.Find(ids[1]).entrant_name;
                return duetNames;
            }

            string trioNames =
                    entities.Entrants.Find(ids[0]).entrant_name + ", " + entities.Entrants.Find(ids[1]).entrant_name
                    + ", " + entities.Entrants.Find(ids[2]).entrant_name;
            return trioNames;
        }
    }
}
