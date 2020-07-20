using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Ugozi_Comparator
{
    public class FullRecord
    {
        public string UBI_ID { get; set; }   
        public string UBI_Name { get; set; }
        public string Description { get; set; }
        public string SourceOfThreat { get; set; }
        public string ObjectOfImpact { get; set; }
        public bool PrivacyViolation { get; set; }
        public bool IntegrityViolation { get; set; }
        public bool AccessViolation { get; set; }

        public FullRecord() { }

        public FullRecord(string id, string name, string description, string source, string objectOfImpact, bool privacyViolation, bool integrityViolation, bool accessViolation)
        {
            UBI_ID = id;
            UBI_Name = name;
            Description = description;
            SourceOfThreat = source;
            ObjectOfImpact = objectOfImpact;
            PrivacyViolation = privacyViolation;
            IntegrityViolation = integrityViolation;
            AccessViolation = accessViolation;
        }

        public void CompareTo(FullRecord fullRecord, ObservableCollection<UpdateRecord> updateRecords)
        {

            string id, name, description, source, objectOfImpact;
            bool privacyViolation, integrityViolation, accessViolation;

            if (this.UBI_ID != fullRecord.UBI_ID)
	        {
                updateRecords.Add(new UpdateRecord("UBI_ID", this.UBI_ID, fullRecord.UBI_ID));
	        }

            if (this.UBI_Name != fullRecord.UBI_Name)
            {
                updateRecords.Add(new UpdateRecord("UBI_Name", this.UBI_Name, fullRecord.UBI_Name));
            }

            if (this.Description != fullRecord.Description)
            {
                updateRecords.Add(new UpdateRecord("Description", this.Description, fullRecord.Description));
            }

            if (this.SourceOfThreat != fullRecord.SourceOfThreat)
            {
                updateRecords.Add(new UpdateRecord("Source_Of_Threat", this.SourceOfThreat, fullRecord.SourceOfThreat));
            }

            if (this.ObjectOfImpact != fullRecord.ObjectOfImpact)
            {
                updateRecords.Add(new UpdateRecord("Object_Of_Impact", this.SourceOfThreat, fullRecord.SourceOfThreat));
            }

            if (this.PrivacyViolation != fullRecord.PrivacyViolation)
            {
                updateRecords.Add(new UpdateRecord("Is_Privacy_Violant", this.PrivacyViolation.ToString(), fullRecord.PrivacyViolation.ToString()));
            }

            if (this.IntegrityViolation != fullRecord.IntegrityViolation)
            {
                updateRecords.Add(new UpdateRecord("Is_Integrity_Violant", this.IntegrityViolation.ToString(), fullRecord.IntegrityViolation.ToString()));
            }

            if (this.AccessViolation != fullRecord.AccessViolation)
            {
                updateRecords.Add(new UpdateRecord("Is_Acsess_Violant", this.AccessViolation.ToString(), fullRecord.AccessViolation.ToString()));
            }
        }

        public static bool operator !=(FullRecord fullRecord1, FullRecord fullRecord2)
        {
            if (fullRecord1.AccessViolation == fullRecord2.AccessViolation && fullRecord1.Description == fullRecord2.Description && fullRecord1.IntegrityViolation == fullRecord2.IntegrityViolation && fullRecord1.ObjectOfImpact == fullRecord2.ObjectOfImpact && fullRecord1.PrivacyViolation == fullRecord2.PrivacyViolation && fullRecord1.SourceOfThreat == fullRecord2.SourceOfThreat && fullRecord1.UBI_ID == fullRecord2.UBI_ID && fullRecord1.UBI_Name == fullRecord2.UBI_Name)
            {
                return false;
            }
            return true;
        }

        public static bool operator ==(FullRecord fullRecord1, FullRecord fullRecord2)
        {
            if (fullRecord1.AccessViolation == fullRecord2.AccessViolation && fullRecord1.Description == fullRecord2.Description && fullRecord1.IntegrityViolation == fullRecord2.IntegrityViolation && fullRecord1.ObjectOfImpact == fullRecord2.ObjectOfImpact && fullRecord1.PrivacyViolation == fullRecord2.PrivacyViolation && fullRecord1.SourceOfThreat == fullRecord2.SourceOfThreat && fullRecord1.UBI_ID == fullRecord2.UBI_ID && fullRecord1.UBI_Name == fullRecord2.UBI_Name)
            {
                return true;
            }
            return false;
        }

        public static explicit operator SmallRecord (FullRecord a)
        {
            return new SmallRecord() { UBI_ID = "УБИ." + a.UBI_ID, UBI_Name = a.UBI_Name };
        }

        public override string ToString()
        {
            return $"UBI_ID = {UBI_ID}; UBI_Name = {UBI_Name}; Description = {Description}; SourceOfThreat = {SourceOfThreat}; Object Of Impact = {ObjectOfImpact}; Is Privacy Violant = {PrivacyViolation}; Is Integrity Violant = {IntegrityViolation}; Is Acsess Violant = {AccessViolation}";
        }
    }
}
