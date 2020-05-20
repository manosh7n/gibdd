using System;
using SQLite;

namespace gibdd
{
    [Table ("ProfileData")]
    public class ProfileData
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        
        // Куда будет адресованно
        public string regionAdressed { get; set; }
        public string subdivision { get; set; }
        public string position { get; set; }
        public string fioAdressed { get; set; }
        
        // Ваши данные
        public string fio { get; set; }
        public bool organisation { get; set; }
        public string organisationName { get; set; }
        public string addInfo { get; set; }
        public int outNumb { get; set; }
        public DateTime organisationDate { get; set; }
        public int letterNumb { get; set; }
        
        // Данные для ответа
        public string email { get; set; }
        public string phone { get; set; }
        public string regionIncident { get; set; }
        
        // Уже обращались?
        public bool alreadyApplied { get; set; }
        public string subdivisionLast { get; set; }
        public DateTime dateAppeal { get; set; }
        
        public ProfileData()
        {
        }
    }
}