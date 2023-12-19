using System;
using UnityEngine;

public class SCR_timer {
    public static SCR_timer create (Action action, float timer, GameObject parent = null, bool contiueLoop = true) { //Create timer
        SCR_timer newTimer = new SCR_timer(action, timer, contiueLoop);

        GameObject obj = new GameObject("My Timer", typeof(hook));
        if (parent is not null) obj.transform.parent = parent.transform;
        obj.GetComponent<hook>().onUpdate = newTimer.Update;

        return newTimer;
    }
    class hook : MonoBehaviour { //Use MonoBehaviour to use update
        public Action onUpdate;
        private void Update() {
            if(onUpdate != null) onUpdate();
        }
    }

    public Action action; //Hold the function reference to run after time runs out
    float timer;
    float maxTimer;
    public bool continueLoop { private set; get; } //Should timer continue? Used to determine if the timer should be reset

    SCR_timer(Action action, float timer, bool continueLoop) { 
        this.action = action;
        this.timer = timer;
        maxTimer = timer;
        this.continueLoop = continueLoop;
    }
    void Update() {
        if(continueLoop) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                if(action != null) action();
                continueLoop = false;
            }
        }
    }
    public void resetSelf() {
        continueLoop = true;
        timer = maxTimer;
    }
    public void changeMax(float maxTimer) {
        this.maxTimer = maxTimer;
    }
}