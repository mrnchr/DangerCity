﻿namespace DangerCity
{
  /// <summary>
  /// Create asset menu constants
  /// </summary>
  public static class CAC
  {
    public const string PROJECT_MENU = "Danger City/";
    public const string CONFIG_MENU = PROJECT_MENU + "Configs/";

    public static class Names
    {
      public const string CONFIG_PROVIDER_FILE = "Config Provider";
      public const string CONFIG_PROVIDER_MENU = CONFIG_MENU + "Config Provider";
      
      public const string PHYSICS_FILE = "Physics Config";
      public const string PHYSICS_MENU = CONFIG_MENU + "Physics";
    }
  }
}