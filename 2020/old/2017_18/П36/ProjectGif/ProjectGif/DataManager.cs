using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectGif
{
    public delegate void InfoGroup(AnimationGroup group);
    public class DataManager
    {
        static public event InfoGroup GroupAdded;
        static public event InfoGroup GroupRefresh;

        static private List<AnimationGroup> Animations;

        static DataManager()
        {
            Animations = new List<AnimationGroup>();
        }

        static public void Add(AnimationGroup group)
        {
            int index = -1;
            for (int i = 0; i < Animations.Count; i++)
            {
                var g = Animations[i];
                if (g.Title == group.Title)
                {
                    index = i;
                    break;
                }
            }
            Array.Sort(group.Numbers);
            if (index > -1)
            {
                Animations[index] = group;
                GroupRefresh?.Invoke(group);
            }
            else
            {
                Animations.Add(group);
                GroupAdded?.Invoke(group);
            }
        }

        static public void Save(string fname)
        {
            var fs = new FileStream(fname, FileMode.Create);
            var xms = new XmlSerializer(typeof(List<AnimationGroup>));
            xms.Serialize(fs, Animations);
            fs.Close();
        }

    }
}
