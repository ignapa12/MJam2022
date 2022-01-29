using MJam22.Beat;
using UnityEngine;
using UnityEngine.Events;

namespace MJam22.Stress
{
    public class StressBehaviour : MonoBehaviour
    {
        [SerializeField] float maxStress;
        [SerializeField] StressView stressView;

        [SerializeField] BeatTrackController beatTrackController;
        
        StressController stressController;
        UnityEvent OnMaxStress = new UnityEvent();

        void Start()
        {
            stressController = new StressController(maxStress, OnMaxStress);
            InitListeners();
            ViewStress();
        }

        void InitListeners()
        {
            beatTrackController?.onNoteOutOfSight.AddListener((NoteBehaviour)=>AddStress(10));
            OnMaxStress.AddListener(()=>Debug.Log("Max Stress"));
        }

        void AddStress(int amount)
        {
            stressController.IncreaseStress(amount);
            ViewStress();
        }

        void ViewStress() => stressView.FillBar(stressController.Stress);
    }
}