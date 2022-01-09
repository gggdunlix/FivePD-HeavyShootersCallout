using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using FivePD.API;
using FivePD.API.Utils;

namespace YouTubeTutorial1
{

    [CalloutProperties("Heavy Shooters", "GGGDunlix", "0.0.1")]
    public class HeavyShooting : Callout
    {
        Ped suspect, suspect2, suspect3, suspect4;

        public HeavyShooting()
        {
            Random random = new Random();
            InitInfo(World.GetNextPositionOnStreet(Game.PlayerPed.GetOffsetPosition(Vector3Extension.Around(Game.PlayerPed.Position, 200f))));
            ShortName = "Heavily Weaponised Active Shooters";
            CalloutDescription = "4 Shooters were spotted with advanced weaponry. Respond in Code 3 High.";
            ResponseCode = 3;
            StartDistance = 120f;
        }

        public async override Task OnAccept()
        {
            InitBlip();
            UpdateData();
            suspect = await SpawnPed(RandomUtils.GetRandomPed(), Location);
            suspect2 = await SpawnPed(RandomUtils.GetRandomPed(), Vector3Extension.Around(suspect.Position, 5f));
            suspect3 = await SpawnPed(RandomUtils.GetRandomPed(), Vector3Extension.Around(suspect.Position, 5f));
            suspect4 = await SpawnPed(RandomUtils.GetRandomPed(), Vector3Extension.Around(suspect.Position, 6f));
            suspect.AlwaysKeepTask = true;
            suspect.BlockPermanentEvents = true;
            suspect2.AlwaysKeepTask = true;
            suspect2.BlockPermanentEvents = true;
            suspect3.AlwaysKeepTask = true;
            suspect3.BlockPermanentEvents = true;
            suspect4.AlwaysKeepTask = true;
            suspect4.BlockPermanentEvents = true;
        }

        public override void OnStart(Ped player)
        {
            base.OnStart(player);

            
            
            suspect.Weapons.Give(WeaponHash.Minigun, 9999, true, true);
            suspect.Task.ShootAt(Game.PlayerPed);
            suspect2.Weapons.Give(WeaponHash.MarksmanRifleMk2, 9999, true, true);
            suspect2.Task.ShootAt(Game.PlayerPed);
            suspect3.Weapons.Give(WeaponHash.CombatMGMk2, 9999, true, true);
            suspect3.Task.ShootAt(Game.PlayerPed);
            suspect4.Weapons.Give(WeaponHash.AssaultRifleMk2, 9999, true, true);
            suspect4.Task.ShootAt(Game.PlayerPed);

            suspect.Armor = 7000;
            suspect2.Armor = 7000;
            suspect3.Armor = 7000;
            suspect4.Armor = 7000;

            suspect.Accuracy = 50;
            suspect2.Accuracy = 80;
            suspect3.Accuracy = 90;
            suspect4.Accuracy = 90;

            suspect.ShootRate = 700;

            suspect.AttachBlip();
            suspect2.AttachBlip();
            suspect3.AttachBlip();
            suspect4.AttachBlip();
        }
    }


    }
