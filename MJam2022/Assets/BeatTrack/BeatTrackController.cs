using System.Linq;
using UnityEngine;

namespace MJam22.Beat
{
    public class BeatTrackController : MonoBehaviour
    {
        [SerializeField] KeyCode inputKey;
        public float beatTempo;
        [SerializeField] GameObject NotePrefab;
        [SerializeField] Transform NoteSpawnPosition;
        
        NoteHolder noteHolder = new NoteHolder();

        void Update()
        {
            MoveNotes();
            TrySpawnNote();
            TryClearNotes();
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
            var note = Instantiate(NotePrefab, NoteSpawnPosition);
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
            noteHolder.RemoveNotes(notesToClear);
            
            foreach(var note in notesToClear)
            {
                Destroy(note.gameObject);
            }
        }
    }   
}
