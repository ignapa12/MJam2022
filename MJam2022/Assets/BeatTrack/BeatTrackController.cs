using System.Linq;
using UnityEngine;
using Utils;

namespace MJam22.Beat
{
    public class BeatTrackController : MonoBehaviour
    {
        [SerializeField] KeyCode inputKey;
        public float beatTempo;
        [SerializeField] GameObject NotePrefab;
        [SerializeField] Transform NoteSpawnPosition;

        readonly NoteHolder noteHolder = new NoteHolder();
        
        #region Events
        readonly NoteBehaviourUnityEvent onNoteOutOfSight = new NoteBehaviourUnityEvent();
        #endregion

        void Start()
        {
            InitListeners();
        }

        void Update()
        {
            MoveNotes();
            TrySpawnNote();
            TryClearNotes();
        }

        void InitListeners()
        {
            onNoteOutOfSight.AddListener(FailNote);
        }

        void MoveNotes()
        {
            noteHolder.MoveNotes(beatTempo);
        }

        void TrySpawnNote()
        {
            if(Input.GetKeyDown(KeyCode.Space))
                SpawnNote();
        }

        void SpawnNote()
        {
            var note = Instantiate(NotePrefab, NoteSpawnPosition).GetComponent<NoteBehaviour>();
            note.SetOnOutOfSight(onNoteOutOfSight);
            noteHolder.AddNote(note);
        }

        void TryClearNotes()
        {
            if(Input.GetKeyDown(inputKey))
                ClearNotes();
        }
        
        void ClearNotes()
        {
            var notesToClear = noteHolder.GetActivatedNotes().ToList();
            Debug.Log($"{notesToClear.Count} notes to clear");

            if(notesToClear.Any())
            {
                var note = notesToClear.First();
                RemoveNote(note);
            }
        }

        void FailNote(NoteBehaviour note)
        {
            RemoveNote(note);
            Debug.Log("Aumenta el estres");
        }

        void RemoveNote(NoteBehaviour note)
        {
            noteHolder.RemoveNotes(note);
            Destroy(note.gameObject);
        }
    }   
}
