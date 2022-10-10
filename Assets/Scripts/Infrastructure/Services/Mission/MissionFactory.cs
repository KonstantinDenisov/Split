using System;
using Split.Infrastructure.Services.Mission.Complex;
using Split.Infrastructure.Services.Mission.KillAllEnemies;
using Split.Infrastructure.Services.Mission.KillOneEnemy;
using Split.Infrastructure.Services.Npc;

namespace Split.Infrastructure.Services.Mission
{
    public static class MissionFactory
    {
        public static Mission[] Create(MissionCondition[] conditions)
        {
            Mission[] missions = new Mission[conditions.Length];
            for (int i = 0; i < conditions.Length; i++)
            {
                missions[i] = Create(conditions[i]);
            }

            return missions;
        }

        public static Mission Create(MissionCondition condition)
        {
            return condition switch
            {
                ComplexMissionCondition complexMissionCondition => throw new NotImplementedException(), // TODO
                KillAllEnemiesMissionCondition killAllCondition => CreateKillAllEnemiesMission(killAllCondition),
                KillOneEnemyMissionCondition killOneCondition => CreateKillOneEnemyMission(killOneCondition),
                _ => null
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

        private static Mission CreateKillOneEnemyMission(KillOneEnemyMissionCondition killOneEnemyMissionCondition)
        {
            var mission = new KillOneEnemyMission();
            mission.SetCondition(killOneEnemyMissionCondition);
            return mission;
        }
    }
}