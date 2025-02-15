﻿namespace GTA5OnlineTools.Features.Client;

public static class EnumData
{
    public enum PedTypes : int
    {
        PLAYER_0,                   //  0 麦克
        PLAYER_1,                   //  1 富兰克林
        NETWORK_PLAYER,             //  2 线上角色
        PLAYER_2,                   //  3 崔佛
        CIVMALE,                    //  4 文明的男性
        CIVFEMALE,                  //  5 文明的女性
        COP,                        //  6 警察
        GANG_ALBANIAN,              //  7 帮派...
        GANG_BIKER_1,               //
        GANG_BIKER_2,               //
        GANG_ITALIAN,               //
        GANG_RUSSIAN,               //
        GANG_RUSSIAN_2,             //
        GANG_IRISH,                 //
        GANG_JAMAICAN,              //
        GANG_AFRICAN_AMERICAN,      // 
        GANG_KOREAN,                // 
        GANG_CHINESE_JAPANESE,      // 
        GANG_PUERTO_RICAN,          //
        DEALER,                     // 19 商人
        MEDIC,                      // 20 医生
        FIREMAN,                    // 21 消防员
        CRIMINAL,                   // 22 罪犯
        BUM,                        // 23 流浪汉
        PROSTITUTE,                 // 24 妓女
        SPECIAL,                    // 25 特殊
        MISSION,                    // 26 任务
        SWAT,                       // 27 特警
        ANIMAL,                     // 28 动物
        ARMY                        // 29 军队
    };

    public enum BlipIcons
    {
        Null,
        Circle,
        Empty,
        Cop,
        CopSearchZone,
        Square,
        PlayerArrow,
        North,
        Waypoint,
        BigCircle,
        BigCircleOutline,
        ArrowUpOutlined,
        ArrowDownOutlined,
        ArrowUp,
        ArrowDown,
        PoliceHelicopter,
        Jet,
        Number1,
        Number2,
        Number3,
        Number4,
        Number5,
        Number6,
        Number7,
        Number8,
        Number9,
        Number10,
        GTAOCrew,
        GTAOFriend,
        CableCar = 36,
        RaceFinish = 38,
        Safehouse = 40,
        Cop2,
        CopCar,
        Helicopter,
        ChatBubble = 47,
        Garage = 50,
        Drugs,
        ConvenienceStore,
        PoliceCar = 56,
        Circle2,
        CircleWithStar,
        ConvenienceStore2,
        ShieldWithStar,
        Asterisk,
        Helicopter2 = 64,
        StrangersAndFreaks = 66,
        ArmoredTruck,
        TowTruck,
        Barber = 71,
        LosSantosCustoms,
        Clothes,
        TattooParlor = 75,
        Simeon,
        Lester,
        Michael,
        Trevor,
        Heist1,
        Rampage = 84,
        VinewoodTours,
        Franklin,
        Franklin2 = 88,
        Chinese,
        FlightSchool,
        Bar = 93,
        ParachuteJump,
        Heist2 = 96,
        CarWash = 100,
        ComedyClub = 102,
        Darts,
        FIB = 106,
        Heist3,
        DollarSign,
        Golf,
        AmmuNation,
        Exile = 112,
        ShootingRange = 119,
        Solomon,
        StripClub,
        Tennis,
        Triathlon = 126,
        OffRoadRaceFinish,
        Key = 134,
        MovieTheater,
        Music,
        Marijuana = 140,
        Hunting,
        ArmsTraffickingGround = 147,
        Nigel = 149,
        AssaultRifle,
        Bat,
        Grenade,
        Health,
        Knife,
        Molotov,
        Pistol,
        RPG,
        Shotgun,
        SMG,
        Sniper,
        SonicWave,
        PointOfInterest,
        GTAOPassive,
        GTAOUsingMenu,
        Link = 171,
        Minigun = 173,
        GrenadeLauncher,
        Armor,
        Castle,
        CameraIcon = 184,
        Handcuffs = 188,
        Yoga = 197,
        Cab,
        Number11,
        Number12,
        Number13,
        Number14,
        Number15,
        Number16,
        Shrink,
        Epsilon,
        PersonalVehicleCar = 225,
        PersonalVehicleBike,
        Custody = 237,
        ArmsTraffickingAir = 251,
        Fairground = 266,
        PropertyManagement,
        Altruist = 269,
        Enemy,
        Chop = 273,
        Dead,
        Hooker = 279,
        Friend,
        BountyHit = 303,
        GTAOMission,
        GTAOSurvival,
        CrateDrop,
        PlaneDrop,
        Sub,
        Race,
        Deathmatch,
        ArmWrestling,
        AmmuNationShootingRange = 313,
        RaceAir,
        RaceCar,
        RaceSea,
        GarbageTruck = 318,
        Motorcycle = 348,
        SafehouseForSale = 350,
        Package,
        MartinMadrazo,
        EnemyHelicopter,
        Boost,
        Devin,
        Marina,
        Garage2,
        GolfFlag,
        Hangar,
        Helipad,
        JerryCan,
        Masks,
        HeistSetup,
        Incapacitated,
        PickupSpawn,
        BoilerSuit,
        Completed,
        Rockets,
        GarageForSale,
        HelipadForSale,
        MarinaForSale,
        HangarForSale,
        Business = 374,
        BusinessForSale,
        RaceBike,
        Parachute,
        TeamDeathmatch,
        RaceFoot,
        VehicleDeathmatch,
        Barry,
        Dom,
        MaryAnn,
        Cletus,
        Josh,
        Minute,
        Omega,
        Tonya,
        Paparazzo,
        Crosshair,
        Creator = 398,
        CreatorDirection,
        Abigail,
        Blimp,
        Repair,
        Testosterone,
        Dinghy,
        Fanatic,
        GangAttack,
        Information,
        CaptureBriefcase,
        LastTeamStanding,
        Boat,
        CaptureHouse,
        JerryCan2 = 415,
        RPLogo,
        GTAOPlayerSafehouse,
        GTAOPlayerSafehouseBounty,
        CaptureAmericanFlag,
        CaptureFlag,
        Tank,
        PlayerHelicopter,
        PlayerPlane,
        PlayerJet,
        PlayerArrowNoColor,
        PlayerLAPV,
        PlayerBoat,
        HeistRoom,
        Stopwatch = 430,
        DollarSignCircled,
        Crosshair2,
        Crosshair3,
        DollarSignSquared,
        RaceFlagWithArrow,
        Fire,
        DoubleDeathmatchSkulls,
        CastleIcon,
        Crown,
        SupplyBag,
        QuadirectionalArrows,
        Fox,
        Triangle,
        ThreeBars,
        LamarDavis,
        Mechanic,
        LamarDavisOne,
        LamarDavisTwo,
        LamarDavisThree,
        LamarDavisFour,
        LamarDavisFive,
        LamarDavisSix,
        LamarDavisSeven,
        LamarDavisEight,
        Yacht,
        SmallQuestionMark,
        GymBag,
        CrosshairWithPersonInMiddle,
        PlayerSpeaking,
        Taxi,
        ShieldWithX,
        YachtMinimap,
        Fox2,
        Hourglass,
        SmallQuestionMark2,
        Stopwatch2,
        Restart,
        SunWithEye,
        Marijuana2,
        Shotgun2,
        Jetski,
        EyeWithLineThroughIt,
        Garage3,
        GarageForSale2,
        Building,
        BuildingForSale,
        Truck,
        Crate,
        Trailer,
        Person,
        Cargobob,
        BigOutlineSquare,
        Speedometer,
        Ghost,
        RemoteControl,
        Bomb,
        Shield,
        StuntRace,
        Heart,
        StuntRaceMoney,
        TeamDeathMatch2,
        HouseWithGarage,
        QuadirectionalArrowsWithMotorcycle,
        CircleWithMotorcycle,
        MotorcycleRace,
        Weed,
        Cocaine,
        ForgedDocuments,
        Meth,
        CounterfeitMoney,
        DrugPickup,
        BigOne,
        BigTwo,
        BigThree,
        BigFour,
        BigFive,
        BigSix,
        BigSeven,
        BigEight,
        BigNine,
        BigTen,
        ATVQuad,
        Bus,
        BagMaybe,
        UpArrowOnSquare,
        FourPlayers,
        EightPlayers,
        TenPlayers,
        TwelvePlayers,
        SixteenPlayers,
        Laptop,
        Supercycle,
        Supercar,
        GarageWithCar,
        PaperDocument,
        ShieldWithBlackStar,
        CraneClaw,
        PhantomWedge,
        BoxvilleArmored,
        Ruiner2000,
        RampBuggy,
        Wastelander,
        RocketVoltic,
        TechnicalAqua,
        LetterA,
        LetterB,
        LetterC,
        LetterD,
        LetterE,
        LetterF,
        LetterG,
        LetterH,
        SkullWithTriangleTop,
        Wrench,
        SteeringWheel,
        Trolphy,
        Rocket,
        Missile,
        Bullets,
        Parachute2,
        Number5WithCircle,
        Number10WithCircle,
        Number15WithCircle,
        Number20WithCircle,
        Number30WithCircle,
        Bullets2,
        Bunker,
        InsurgentPickup,
        Opressor,
        TechnicalCustom,
        DuneFAV,
        HalfTrack,
        AntiAircraftTrailer,
        Satelite,
        BunkerWithPeople,
        ScrewdriverAndHammer,
        UpgradedWeaponWorkbench,
        CrateWithStraps,
        AircraftHanger,
        Icosikaitetragon,
        RaceflagWithQuestionmark,
        AlphaZ1,
        Bombushka,
        Havok,
        HowardNX25,
        Hunter,
        Ultralight,
        Mogul,
        Molotok,
        Nokota,
        Pyro,
        Rogue,
        Starling,
        Starbreeze,
        Tula,
        GymBagWithLetterH,
        LockedCrate,
        SateliteIcon,
        Avenger,
        IAAFacility,
        DoomsdayHeist,
        SAMTurret,
        HackingPuzzleRed,
        HackingPuzzleDiode,
        Stromburg,
        Deluxo,
        ThrusterJetpack,
        TM02KhanjaliTank,
        RCV,
        Volatol,
        Barrage,
        Akula,
        Chernobog,
        SpeakerMaybe,
        YellowishBrownMoneySign,
        ComputerTerminal,
        HackingPuzzleMirror,
        HackingPuzzleReflector,
        HackingPuzzleRotator,
        RaceFlagWithCrosshair,
        RaceFlagWithSteeringWheel,
        SeaSparrow,
        Caracara,
        Nightclub,
        CrateB,
        VanB,
        Diamond,
        BullionStacks,
        CalculatorMaybe,
        CarWithLightningBolt,
        HeartIcon,
        StarWithAdd,
        StarWithSubtract,
        BombWithAdd,
        BombWithSubtract,
        CrosshairDJ,
        Drone,
        Cashregister,
        SpeakerMaybeBigger,
        Skull,
        FestivalBus,
        Terrorbyte,
        Menacer,
        Scramjet,
        PounderCustom,
        MuleCustom,
        SpeedoCustom,
        BlimpIcon,
        OpressorMKII,
        B11StrikeForce,
        GearWithCar,
        GearWithMoney,
        GearWithWrench,
        RaceFlagWithGear,
        CrosshairOnCar,
        RCBandito,
        RCRemote,
        FlameSign,
        ArrowSign,
        GearSign,
        RepeatSign,
        DownArrowSign,
        ExplosionSign,
        WheelExplosionSign,
        ElevatorSign,
        ElevatorSign2,
        EjectorPlatformSign,
        Bruiser,
        Brutus,
        Cerberus,
        Deathbike,
        Dominator,
        Impaler,
        Imperator,
        Issi,
        Sasquatch,
        Scarab,
        Slamvan,
        ZR380
    }

    public enum BlipColors
    {
        None,
        Red,
        Green,
        Blue,
        PlayerColor,
        YellowMission,
        FriendlyVehicle = 0x26,
        MichaelColor = 0x2A,
        FranklinColor,
        TravorColor,
        BlipColorEnemy = 0x31,
        MissionVehicle = 0x36,
        RedMission = 0x3B,
        YellowMission2 = 0x3C,
        Mission = 0x42,
        WaypointColor = 0x54
    }
}
