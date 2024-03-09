using Mario.Entities.Character.HeroStates;
using Mario.Interfaces.Entities;
using System;
using System.Collections.Generic;
using static Mario.Global.HeroVariables;

namespace Mario.Entities.Hero
{
    public class HeroStateManager
    {
        private IHero hero;
        Dictionary<(HeroStateType, int), HeroState> stateMap = new Dictionary<(HeroStateType, int), HeroState>
        {
            [(HeroStateType.StandingRight, 1)] = new StandingRightState(),
            [(HeroStateType.StandingLeft, 1)] = new StandingLeftState(),
            [(HeroStateType.MovingRight, 1)] = new MovingRightState(),
            [(HeroStateType.MovingLeft, 1)] = new MovingLeftState(),
            [(HeroStateType.JumpingRight, 1)] = new JumpRightState(),
            [(HeroStateType.JumpingLeft, 1)] = new JumpLeftState(),
            [(HeroStateType.Dead, 1)] = new DeadState(),
            [(HeroStateType.StandingRight, 2)] = new StandingRightBigState(),
            [(HeroStateType.StandingLeft, 2)] = new StandingLeftBigState(),
            [(HeroStateType.MovingRight, 2)] = new MovingRightBigState(),
            [(HeroStateType.MovingLeft, 2)] = new MovingLeftBigState(),
            [(HeroStateType.JumpingRight, 2)] = new JumpRightBigState(),
            [(HeroStateType.JumpingLeft, 2)] = new JumpLeftBigState(),
            [(HeroStateType.Crouching, 2)] = new CrouchBigState(),
            [(HeroStateType.Dead, 2)] = new DeadState(),
            [(HeroStateType.StandingRight, 3)] = new StandingRightFireState(),
            [(HeroStateType.StandingLeft, 3)] = new StandingLeftFireState(),
            [(HeroStateType.MovingRight, 3)] = new MovingRightFireState(),
            [(HeroStateType.JumpingRight, 2)] = new JumpRightFireState(),
            [(HeroStateType.MovingLeft, 3)] = new MovingLeftFireState(),
            [(HeroStateType.JumpingLeft, 3)] = new JumpLeftFireState(),
            [(HeroStateType.Crouching, 3)] = new CrouchFireState(),
            [(HeroStateType.Dead, 3)] = new DeadState(),
        };

        public HeroStateManager(IHero hero)
        {
            this.hero = hero;
        }
        public void SetState(HeroStateType state, int health)
        {
            if (stateMap.TryGetValue((state, health), out var heroState))
            {
                hero.currentState = heroState;
            }
        }
        public HeroStateType GetStateType()
        {
            foreach (var entry in stateMap)
            {
                if (hero.currentState == entry.Value)
                {
                    return entry.Key.Item1; // Return the HeroStateType from the key tuple
                }
            }
            Logger.Instance.LogError("Current state is not in the state map.");
            throw new Exception("Current state is not in the state map.");
        }
    }
}
