﻿using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using KitchenLib.References;
using System.Reflection;

namespace KitchenMacAndCheese
{
    public class Mac_Ketchup_Upgrade : CustomDish
    {
        public override string UniqueNameID => "Mac Ketchup";

        public override DishType Type => DishType.Extra;
        public override string AchievementName => "";
        public override GameObject IconPrefab => null;
        public override GameObject DisplayPrefab => null;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override bool IsUnlockable => true;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override int MinimumFranchiseTier => 0;
        public override bool IsSpecificFranchiseTier => false;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override float SelectionBias => 0;
        public override HashSet<Dish.IngredientUnlock> ExtraOrderUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                MenuItem = (ItemGroup)GDOUtils.GetCustomGameDataObject<Plated_Mac>().GameDataObject,
                Ingredient = (Item)GDOUtils.GetExistingGDO(ItemReferences.CondimentKetchup)
            },
            new Dish.IngredientUnlock
            {
                MenuItem = (ItemGroup)GDOUtils.GetCustomGameDataObject<Plated_Dogged_Mac>().GameDataObject,
                Ingredient = (Item)GDOUtils.GetExistingGDO(ItemReferences.CondimentKetchup)
            },
            new Dish.IngredientUnlock
            {
                MenuItem = (ItemGroup)GDOUtils.GetCustomGameDataObject<Plated_Egged_Mac>().GameDataObject,
                Ingredient = (Item)GDOUtils.GetExistingGDO(ItemReferences.CondimentKetchup)
            },
            new Dish.IngredientUnlock
            {
                MenuItem = (ItemGroup)GDOUtils.GetCustomGameDataObject<Plated_Egged_Dogged_Mac>().GameDataObject,
                Ingredient = (Item)GDOUtils.GetExistingGDO(ItemReferences.CondimentKetchup)
            }
        };
        public override List<Unlock> HardcodedBlockers => new List<Unlock> { };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            (Item)GDOUtils.GetExistingGDO(ItemReferences.CondimentKetchup)
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Give customers ketchup after serving them their food." }
        };
        public override List<Unlock> HardcodedRequirements => new List<Unlock> { 
            (Unlock)GDOUtils.GetCustomGameDataObject<Plated_Mac_Dish>().GameDataObject 
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Dish dish = (Dish)gameDataObject;
            LocalisationObject<UnlockInfo> info = new LocalisationObject<UnlockInfo>();
            FieldInfo dictionary = ReflectionUtils.GetField<LocalisationObject<UnlockInfo>>("Dictionary");
            Dictionary<Locale, UnlockInfo> dict = new Dictionary<Locale, UnlockInfo>();
            dict.Add(Locale.English, new UnlockInfo
            {
                Name = "Mac N Cheese - Ketchup",
                Description = "Adds Ketchup as a condiment option."
            });
            dictionary.SetValue(info, dict);
            dish.Info = info;
        }
    }
}
