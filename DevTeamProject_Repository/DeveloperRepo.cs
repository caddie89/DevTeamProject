using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<DeveloperInformation> _developerDirectory = new List<DeveloperInformation>();

        //Developer Create
        public void AddDevToList(DeveloperInformation developer)
        {
            _developerDirectory.Add(developer);
        }
        //Developer Read
        public List<DeveloperInformation> GetDeveloperList()
        {
            return _developerDirectory;
        }

        //Developer Update
        public bool UpdateExistingDeveloper(int originalDeveloper, DeveloperInformation newDeveloper)
        {
            //Find the content
            DeveloperInformation existingDeveloper = GetDeveloperByID(originalDeveloper);

            if (existingDeveloper != null)
            {
                existingDeveloper.DevID = newDeveloper.DevID;
                existingDeveloper.DevName = newDeveloper.DevName;
                existingDeveloper.HasPluralAccess = newDeveloper.HasPluralAccess;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Developer Delete

        public bool RemoveDeveloperFromList(int id)
        {
            DeveloperInformation identity = GetDeveloperByID(id);

            if (identity == null)
            {
                return false;
            }

            int initialCount = _developerDirectory.Count;
            _developerDirectory.Remove(identity);

            if (initialCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Developer Helper (Get Developer by ID)
        public DeveloperInformation GetDeveloperByID(int id)
        {
            foreach (DeveloperInformation identity in _developerDirectory)
            {
                if (identity.DevID == id)
                {
                    return identity;
                }
            }

            return null;
        }
    }
}
