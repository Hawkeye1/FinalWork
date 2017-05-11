using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalWork
{
    [SerializableAttribute]
    public class Options
    {
        public Int32 Accuracy { get; set; }
        Int32 period;
        public Int32 Period
        {
            get
            {
                return period;
            }
            set
            {
                if (value > 0)
                {
                    period = value;
                }
            }
        }
        public Boolean SaveCopy { get; set; }
        public String FilePath { get; set; }

        public Options()
        {
            Accuracy = 2;
            Period = 6;
            SaveCopy = true;
            FilePath = "settings.fw";
        }
        public Options(string s)
        {
            // Инициализация данных из файла
            // Если файл отсутствует то создаем его
            // и инициализируем значениями по умолчанию
            if (!File.Exists(s))                                                           
            {
                using (FileStream fs = File.Create(s))                                     
                {
                    Options o = new Options();

                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fs, o);

                    Accuracy = o.Accuracy;
                    Period = o.Period;
                    SaveCopy = o.SaveCopy;
                    FilePath = s;
                }
            }
            else                                                                            
            {
                using (FileStream fs = File.OpenRead(s))
                {
                    Options o = null;
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    o = (Options)binaryFormatter.Deserialize(fs);

                    Accuracy = o.Accuracy;
                    Period = o.Period;
                    SaveCopy = o.SaveCopy;
                    FilePath = o.FilePath;
                }
            }
        }
        public void SaveChange()
        {
            using (FileStream fs = File.Create(FilePath))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, this);
            }
        }
    }
}
