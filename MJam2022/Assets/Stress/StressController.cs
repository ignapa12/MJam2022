﻿using UnityEngine.Events;

namespace MJam22.Stress
{
    public class StressController
    {
        public float Stress => stressAmount;
        float stressAmount = 10;
        float maxStress = 100;
        UnityEvent onMaxStress;

        public StressController(float maxStress, UnityEvent onMaxStress)
        {
            this.maxStress = maxStress;
            this.onMaxStress = onMaxStress;
        }

        public void IncreaseStress(float amount)
        {
            stressAmount += amount;
            CheckStress();
        }

        void CheckStress()
        {
            if(stressAmount >= maxStress)
                onMaxStress.Invoke();
        }
    }
}