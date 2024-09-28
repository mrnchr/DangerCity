using System;
using DangerCity.Infrastructure;
using UnityEngine;

namespace DangerCity.Gameplay.Hero
{
  [Serializable]
  public class HeroModel
  {
    public CallbackValue<bool> CanMove = new CallbackValue<bool>(true);
    public CallbackValue<bool> IsDie = new CallbackValue<bool>();
    public CallbackValue<bool> IsLadder = new CallbackValue<bool>();
    public CallbackValue<bool> IsJump = new CallbackValue<bool>();
    public CallbackValue<bool> OnGround = new CallbackValue<bool>();
    public CallbackValue<bool> IsWalk = new CallbackValue<bool>();
    public CallbackValue<bool> IsMove = new CallbackValue<bool>();
    public CallbackValue<bool> CanTeleport = new CallbackValue<bool>();
    public CallbackValue<bool> IsExit = new CallbackValue<bool>();
    public CallbackValue<float> BodyDirection = new CallbackValue<float>(1);
    public Vector3 TeleportPosition;
  }
}