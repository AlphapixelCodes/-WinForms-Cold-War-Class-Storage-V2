using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cold_War_Class_Storage_V2
{
    public static class BuildManager
    {
        public static ClassBuild CurrentBuild;
        public static List<ClassBuild> builds = new List<ClassBuild>();
        public static ClassBuild newBuild()
        {
            ClassBuild cb = new ClassBuild();
            cb.Name = getNextAvailableName("Unnamed Build").ToUpper();
            builds.Add(cb);
            return cb;
        }
        public static bool hasBuild(string name)
        {
            return builds.Any(e => e.Name.Equals(name));
        }
        public static string getNextAvailableName(string name)
        {
            int i = 1;
            while (hasBuild(name+i))
            {
                i++;
            }
            return name + i;
        }

        public static ClassBuild GetBuildByName(string name)
        {
            if (!hasBuild(name))
                return null;
            return builds.First(e => e.Name.Equals(name));
        }
    }
}
