using System;

namespace Pen_and_Paper_Visualator.Class
{
    public static class ChatboxMessages
    {
        public static void PlayerRewardedExperience(string playerName, int expValue)
        {
            if (Global._UserState == Global.UserState.Player)
                Global.PlayerForm.ChatBox(String.Format("Player {0} is rewarded {1} experience.", playerName, expValue), "", (int)RtfHelper.FontColorEnum.Yellow, (int)RtfHelper.FontColorEnum.Yellow);
            else
                Global.GameManagerForm.ChatBox(String.Format("Player {0} is rewarded {1} experience.", playerName, expValue), "", (int)RtfHelper.FontColorEnum.Yellow, (int)RtfHelper.FontColorEnum.Yellow);
        }

        public static void PlayerAcquiredCash(string playerName, int value)
        {
            if (Global._UserState == Global.UserState.Player)
                Global.PlayerForm.ChatBox(String.Format("Player {0} has acquired ${1}.", playerName, value), "", (int)RtfHelper.FontColorEnum.Green, (int)RtfHelper.FontColorEnum.Green);
            else
                Global.GameManagerForm.ChatBox(String.Format("Player {0} has acquired ${1}.", playerName, value), "", (int)RtfHelper.FontColorEnum.Green, (int)RtfHelper.FontColorEnum.Green);
        }

        public static void PlayerSpentLostCash(string playerName, int value)
        {
            if (Global._UserState == Global.UserState.Player)
                Global.PlayerForm.ChatBox(String.Format("Player {0} has spent/lost ${1}.", playerName, value), "", (int)RtfHelper.FontColorEnum.Green, (int)RtfHelper.FontColorEnum.Green);
            else
                Global.GameManagerForm.ChatBox(String.Format("Player {0} has spent/lost ${1}.", playerName, value), "", (int)RtfHelper.FontColorEnum.Green, (int)RtfHelper.FontColorEnum.Green);
        }

        public static void PlayerAcquiredItem(string playerName, string itemName)
        {
            if (Global._UserState == Global.UserState.Player)
                Global.PlayerForm.ChatBox(String.Format("Player {0} has acquired a {1}.", playerName, itemName), "", (int)RtfHelper.FontColorEnum.Brown, (int)RtfHelper.FontColorEnum.Brown);
            else
                Global.GameManagerForm.ChatBox(String.Format("Player {0} has acquired a {1}.", playerName, itemName), "", (int)RtfHelper.FontColorEnum.Brown, (int)RtfHelper.FontColorEnum.Brown);
        }

        public static void PlayerRemoveLostItem(string playerName, string itemName)
        {
            if (Global._UserState == Global.UserState.Player)
                Global.PlayerForm.ChatBox(String.Format("Player {0} has sold/lost a {1}.", playerName, itemName), "", (int)RtfHelper.FontColorEnum.Brown, (int)RtfHelper.FontColorEnum.Brown);
            else
                Global.GameManagerForm.ChatBox(String.Format("Player {0} has sold/lost a {1}.", playerName, itemName), "", (int)RtfHelper.FontColorEnum.Brown, (int)RtfHelper.FontColorEnum.Brown);
        }

        public static void PlayerRequestPurchase(string playerName, string itemName)
        {
            if (Global._UserState == Global.UserState.Player)
                Global.PlayerForm.ChatBox(String.Format("Player {0} has requested to purchase a {1}.", playerName, itemName), "", (int)RtfHelper.FontColorEnum.Purple, (int)RtfHelper.FontColorEnum.Purple);
            else
                Global.GameManagerForm.ChatBox(String.Format("Player {0} has requested to purchase a {1}.", playerName, itemName), "", (int)RtfHelper.FontColorEnum.Purple, (int)RtfHelper.FontColorEnum.Purple);
        }

        public static void MapAvailable()
        {
            if (Global._UserState == Global.UserState.Player)
                Global.PlayerForm.ChatBox("A map is now available to view.", "", (int)RtfHelper.FontColorEnum.White, (int)RtfHelper.FontColorEnum.Blue);
            else
                Global.GameManagerForm.ChatBox("A map is now available to view.", "", (int)RtfHelper.FontColorEnum.White, (int)RtfHelper.FontColorEnum.Blue);
        }

        public static void PlayerRequestSell(string playerName, string itemName)
        {
            if (Global._UserState == Global.UserState.Player)
                Global.PlayerForm.ChatBox(String.Format("Player {0} has requested to sell a {1}.", playerName, itemName), "", (int)RtfHelper.FontColorEnum.Purple, (int)RtfHelper.FontColorEnum.Purple);
            else
                Global.GameManagerForm.ChatBox(String.Format("Player {0} has requested to sell a {1}.", playerName, itemName), "", (int)RtfHelper.FontColorEnum.Purple, (int)RtfHelper.FontColorEnum.Purple);
        }

        public static void CombatDamageWeapon(string attackingPlayerName, string victimPlayerName, string weaponName, bool success, int totalDamage)
        {
            if (success)
            {
                if (Global._UserState == Global.UserState.Player)
                    Global.PlayerForm.CombatChatBox(String.Format("{0} attacks {1} with his/her {2} for {3} damage.", attackingPlayerName, victimPlayerName, weaponName, totalDamage), "", (int)RtfHelper.FontColorEnum.White, (int)RtfHelper.FontColorEnum.Red);
                else
                    Global.GameManagerForm.CombatChatBox(String.Format("{0} attacks {1} with his/her {2} for {3} damage.", attackingPlayerName, victimPlayerName, weaponName, totalDamage), "", (int)RtfHelper.FontColorEnum.White, (int)RtfHelper.FontColorEnum.Red);
            }
            else
            {
                if (Global._UserState == Global.UserState.Player)
                    Global.PlayerForm.CombatChatBox(String.Format("{0} attacks {1} with his/her {2} but missed.", attackingPlayerName, victimPlayerName, weaponName), "", (int)RtfHelper.FontColorEnum.White, (int)RtfHelper.FontColorEnum.Red);
                else
                    Global.GameManagerForm.CombatChatBox(String.Format("{0} attacks {1} with his/her {2} but missed.", attackingPlayerName, victimPlayerName, weaponName), "", (int)RtfHelper.FontColorEnum.White, (int)RtfHelper.FontColorEnum.Red);
            }            
        }

        public static void CombatDamageAbility(string attackingPlayerName, string victimPlayerName, string abilityName, bool success, int totalDamage)
        {
            if (success)
            {
                if (Global._UserState == Global.UserState.Player)
                    Global.PlayerForm.CombatChatBox(String.Format("{0} uses {1} to attack {2} for {3} damage.", attackingPlayerName, abilityName, victimPlayerName, totalDamage), "", (int)RtfHelper.FontColorEnum.White, (int)RtfHelper.FontColorEnum.Red);
                else
                    Global.GameManagerForm.CombatChatBox(String.Format("{0} uses {1} to attack {2} for {3} damage.", attackingPlayerName, abilityName, victimPlayerName, totalDamage), "", (int)RtfHelper.FontColorEnum.White, (int)RtfHelper.FontColorEnum.Red);
            }
            else
            {
                if (Global._UserState == Global.UserState.Player)
                    Global.PlayerForm.CombatChatBox(String.Format("{0} attempted to use {1} to attack {2} but failed.", attackingPlayerName, abilityName, victimPlayerName), "", (int)RtfHelper.FontColorEnum.White, (int)RtfHelper.FontColorEnum.Red);
                else
                    Global.GameManagerForm.CombatChatBox(String.Format("{0} attempted to use {1} to attack {2} but failed.", attackingPlayerName, abilityName, victimPlayerName), "", (int)RtfHelper.FontColorEnum.White, (int)RtfHelper.FontColorEnum.Red);
            }
        }

        public static void CombatDamageGeneral(string attackingPlayerName, string victimPlayerName, bool success, int totalDamage)
        {
            if (success)
            {
                if (Global._UserState == Global.UserState.Player)
                    Global.PlayerForm.CombatChatBox(String.Format("{0} attacks {2} for {3} damage.", attackingPlayerName, victimPlayerName, totalDamage), "", (int)RtfHelper.FontColorEnum.White, (int)RtfHelper.FontColorEnum.Red);
                else
                    Global.GameManagerForm.CombatChatBox(String.Format("{0} attacks {2} for {3} damage.", attackingPlayerName, victimPlayerName, totalDamage), "", (int)RtfHelper.FontColorEnum.White, (int)RtfHelper.FontColorEnum.Red);
            }
            else
            {
                if (Global._UserState == Global.UserState.Player)
                    Global.PlayerForm.CombatChatBox(String.Format("{0} attacks {2} but missed.", attackingPlayerName, victimPlayerName), "", (int)RtfHelper.FontColorEnum.White, (int)RtfHelper.FontColorEnum.Red);
                else
                    Global.GameManagerForm.CombatChatBox(String.Format("{0} attacks {2} but missed.", attackingPlayerName, victimPlayerName), "", (int)RtfHelper.FontColorEnum.White, (int)RtfHelper.FontColorEnum.Red);
            }            
        }

        public static void CombatCharacterDead(string victimPlayerName)
        {
            if (Global._UserState == Global.UserState.Player)
                Global.PlayerForm.CombatChatBox(String.Format("{0} has succomed to his/her wounds.", victimPlayerName), "", (int)RtfHelper.FontColorEnum.OffWhite, (int)RtfHelper.FontColorEnum.OffWhite);
            else
                Global.GameManagerForm.CombatChatBox(String.Format("{0} has succomed to his/her wounds.", victimPlayerName), "", (int)RtfHelper.FontColorEnum.OffWhite, (int)RtfHelper.FontColorEnum.OffWhite);
        }

        public static void CombatAddCombatant(string characterName)
        {
            if (Global._UserState == Global.UserState.Player)
                Global.PlayerForm.CombatChatBox(String.Format("{0} has entered the fray.", characterName), "", (int)RtfHelper.FontColorEnum.OffWhite, (int)RtfHelper.FontColorEnum.OffWhite);
            else
                Global.GameManagerForm.CombatChatBox(String.Format("{0} has entered the fray.", characterName), "", (int)RtfHelper.FontColorEnum.OffWhite, (int)RtfHelper.FontColorEnum.OffWhite);
        }
    }
}
