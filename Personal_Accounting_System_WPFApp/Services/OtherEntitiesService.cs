using Personal_Accounting_System_WPFApp.Dtos;
using Personal_Accounting_System_WPFApp.Repositories;
using System.Collections.Generic;

namespace Personal_Accounting_System_WPFApp.Services
{
    class OtherEntitiesService
    {
        private readonly OtherEntitiesRepository otherEntitiesRepository;

        public OtherEntitiesService()
        {
            otherEntitiesRepository = new OtherEntitiesRepository();
        }
        
        public void AddOtherEntities(OtherEntitiesDto otherEntities)
        {
            otherEntitiesRepository.AddOtherEntities(otherEntities);
        }

        public List<OtherEntitiesDto> GetOtherEntities()
        {
            return otherEntitiesRepository.GetOtherEntities();
        }

        public int GetOtherEntitiesId(string otherEntitiesName)
        {
            return otherEntitiesRepository.GetOtherEntitiesId(otherEntitiesName);
        }

        public void ModifyOtherEntities(OtherEntitiesDto otherEntities)
        {
            otherEntitiesRepository.ModifyOtherEntities(otherEntities);
        }

        public void DisableOtheEntities(OtherEntitiesDto otherEntities)
        {
            otherEntitiesRepository.DisableOtherEntities(otherEntities);
        }
    }
}
