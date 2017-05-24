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
    public class Settings
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
        // 0 - часы работы, 1 - выходные дни, 2 - дней в командировке, 3 - дней на больничном
        // 4 - тар. коэфф., 5 - ставка, 6 - (К) 
        public Boolean[] ColumnsVisible { get; set; } 
        public String FilePath { get; set; }

        public Settings()
        {
            Accuracy = 2;
            Period = 6;
            SaveCopy = true;
            FilePath = "settings.fw";
            ColumnsVisible = new Boolean[7];

            for (int i = 0; i < 7; i++)
            {
                ColumnsVisible[i] = true;
            }
        }
        public Settings(string s)
        {
            // Инициализация данных из файла
            // Если файл отсутствует то создаем его
            // и инициализируем значениями по умолчанию
            if (!File.Exists(s))                                                           
            {
                using (FileStream fs = File.Create(s))                                     
                {
                    Settings o = new Settings();

                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fs, o);

                    Accuracy = o.Accuracy;
                    Period = o.Period;
                    SaveCopy = o.SaveCopy;
                    FilePath = s;
                    ColumnsVisible = new Boolean[7];
                    for (int i = 0; i < 7; i++)
                    {
                        ColumnsVisible[i] = o.ColumnsVisible[i];
                    }
                }
            }
            else                                                                            
            {
                using (FileStream fs = File.OpenRead(s))
                {
                    Settings o = null;
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    o = (Settings)binaryFormatter.Deserialize(fs);

                    Accuracy = o.Accuracy;
                    Period = o.Period;
                    SaveCopy = o.SaveCopy;
                    FilePath = o.FilePath;
                    ColumnsVisible = new Boolean[7];
                    for (int i = 0; i < 7; i++)
                    {
                        ColumnsVisible[i] = o.ColumnsVisible[i];
                    }
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
