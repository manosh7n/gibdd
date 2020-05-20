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
        public string outNumb { get; set; }
        public string organisationDate { get; set; }
        public string letterNumb { get; set; }
        
        // Данные для ответа
        public string email { get; set; }
        public string phone { get; set; }
        public string regionIncident { get; set; }
        
        // Уже обращались?
        public bool alreadyApplied { get; set; }
        public string subdivisionLast { get; set; }
        public string dateAppeal { get; set; }
        
        public ProfileData()
        {
        }

        public ProfileData(
            string regionAdressed, 
            string subdivision,
            string position,
            string fioAdressed,
            bool organisation,
            string fio,
            string organisationName, 
            string addInfo, 
            string outNumb,
            string organisationDate,
            string letterNumb,
            string email,
            string phone,
            string regionIncident,
            bool alreadyApplied,
            string subdivisionLast,
            string dateAppeal)
        {
            this.regionAdressed = regionAdressed;
            this.subdivision = subdivision;
            this.position = position;
            this.fioAdressed = fioAdressed;
            this.fio = fio;
            this.organisation = organisation;
            this.organisationName = organisationName;
            this.addInfo = addInfo;
            this.outNumb = outNumb;
            this.organisationDate = organisationDate;
            this.letterNumb = letterNumb;
            this.email = email;
            this.phone = phone;
            this.regionIncident = regionIncident;
            this.alreadyApplied = alreadyApplied;
            this.subdivisionLast = subdivisionLast;
            this.dateAppeal = dateAppeal;
        }
    }
}