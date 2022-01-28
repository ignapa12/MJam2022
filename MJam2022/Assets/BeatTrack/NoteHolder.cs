using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MJam22.Beat
{
    public class NoteHolder
    {
        List<NoteBehaviour> currentNotes;

        public NoteHolder()
        {
            currentNotes = new List<NoteBehaviour>();
        }

        public void AddNote(GameObject note) => currentNotes.Add(note.GetComponent<NoteBehaviour>());

        public void MoveNotes(float beatTempo)
        {
            foreach(var note in currentNotes)
            {
                note.transform.position -= new Vector3(0f, beatTempo/60f * Time.deltaTime, 0f);
            }
        }

        public IEnumerable<NoteBehaviour> GetActivatedNotes()
        {
            return currentNotes.Where(note => note.CanBePressed);
        }

        public void RemoveNotes(List<NoteBehaviour> notes)
        {
            foreach(var note in notes)
            {
                currentNotes.Remove(note);
            }
        }
    }
}