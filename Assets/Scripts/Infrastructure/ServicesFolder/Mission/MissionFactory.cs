using System;
using Split.Infrastructure.ServicesFolder.Mission.Complex;
using Split.Infrastructure.ServicesFolder.Mission.KillAllEnemies;
using Split.Infrastructure.ServicesFolder.Mission.KillOneEnemy;
using Split.Infrastructure.ServicesFolder.Npc;

namespace Split.Infrastructure.ServicesFolder.Mission
{
    public static class MissionFactory
    {
        public static ServicesFolder.Mission.Mission[] Create(MissionCondition[] conditions)
        {
            ServicesFolder.Mission.Mission[] missions = new ServicesFolder.Mission.Mission[conditions.Length];
            for (int i = 0; i < conditions.Length; i++)
            {
                missions[i] = Create(conditions[i]);
            }

            return missions;
        }

        public static ServicesFolder.Mission.Mission Create(MissionCondition condition)
        {
            return condition switch
            {
                ComplexMissionCondition complexMissionCondition => throw new NotImplementedException(), 
                KillAllEnemiesMissionCondition killAllCondition => CreateKillAllEnemiesMission(killAllCondition),
            };
        }

        private static KillAllEnemiesMission CreateKillAllEnemiesMission(
            KillAllEnemiesMissionCondition killAllEnemiesMissionCondition)
        {
            INpcService npcService = ServicesContainer.Services.Container.Get<INpcService>();
            var mission = new KillAllEnemiesMission(npcService);
            mission.SetCondition(killAllEnemiesMissionCondition);
            return mission;
        }

        
    }
}