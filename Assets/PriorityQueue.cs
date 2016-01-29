using UnityEngine;
using System.Collections;

public class PriorityQueue
{

    PQueueEntry head;
    int size;

    public PriorityQueue() {
        head = null;
        size = 0;
    }

    private void add(PQueueEntry a) {
        
        if (head != null) {
            a.setNext(head);
            head.setPrev(a);
        }

        head = a;
        size++;
    }

    private void delete(PQueueEntry a)
    {

        if (a.getPrev() == null && a.getNext() == null)
        {
            head = null;
        } else {
            if (a.getPrev() == null) {
                a.getNext().setPrev(null);
                head = a.getNext();
            } else {
                a.getPrev().setNext(a.getNext());
            } if (a.getNext() == null) {
                a.getPrev().setNext(null);
            } else {
                a.getNext().setPrev(a.getPrev());
            }
        }

        size--;
    }

    public void insert(GameObject gameObj, int priority)
    {
        add(new PQueueEntry(gameObj, priority));
    }
    
    public GameObject removeMin()
    {
        PQueueEntry a = head;
        PQueueEntry minEntry = new PQueueEntry(null , int.MaxValue);

        while (a != null)
        {
           if(a.getPriority() <= minEntry.getPriority())
            {
                minEntry = a;       
            }
            a = a.getNext();
        } 

        delete(minEntry);
        return minEntry.getGameObject();
    }

    public bool removeValue(GameObject gameObj)
    {
        PQueueEntry a = head;

        while (a != null)
        {
            if (a.getGameObject() == gameObj)
            {
                delete(a);
                return true;
            }
            a = a.getNext();
        }
        return false;
    }

    public int minPriority()
    {
        PQueueEntry a = head;
        PQueueEntry minEntry = new PQueueEntry(null, int.MaxValue);

        while (a != null)
        {
            if (a.getPriority() < minEntry.getPriority())
            {
                minEntry = a;
            }
            a = a.getNext();
        }

        return minEntry.getPriority();
    }

    public class PQueueEntry
    {
        GameObject gameObj;
        int priority;
        PQueueEntry next;
        PQueueEntry prev;

        public PQueueEntry(GameObject gameObj, int priority)
        {
            this.gameObj = gameObj;
            this.priority = priority;
            this.next = null;
            this.prev = null;
        }

        public void setNext(PQueueEntry newNext) {
            next = newNext;
        }

        public void setPrev(PQueueEntry newPrev)
        {
            prev = newPrev;
        }

        public PQueueEntry getNext()
        {
            return next;
        }

        public PQueueEntry getPrev()
        {
            return prev;
        }
        public int getPriority()
        {
            return priority;
        }
        public GameObject getGameObject()
        {
            return gameObj;
        }

    }

}

