using System; //native .net system unity uses to run scripts
using UnityEngine;
//public class Clock : UnityEngine.MonoBehaviour { } //referencing unity namespace if not declaring using UnityEngine up top.
public class Clock : MonoBehaviour {



    //public Transform hoursTransform; //instantiate data field
    //or UnityEngine.Transform
    //public Transform minutesTransform;
    //public Transform secondsTransform;
    const float 
        degreesPerHour = 30f,
        degreesPerMinute = 6f,
		degreesPerSecond = 6f;

    public Transform hoursTransform, minutesTransform, secondsTransform;
    public bool continuous;
    //define a method
    //awake is invoked once at start up
    //void Awake () {
    void UpdateContinuous(){
        
    //Debug.Log(DateTime.Now + "hi");
    TimeSpan time = DateTime.Now.TimeOfDay;
        hoursTransform.localRotation =
            Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f); //f suffix added to both numbers to declare floating point data type
        minutesTransform.localRotation =
        Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
        secondsTransform.localRotation =
            Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
        //localRotation refers to the actual rotation of a transform
        //component, independent of the rotation of it's parents.

        //Rotations are stored in Unity as quaternions. We can create one via the publicly-available Quaternion.Euler method. 
        //It has regular angles for the X, Y, and Z axis as parameters and produces an appropriate quaternion.

    }
    //we just want to execute some code, without providing a resulting value. 
    //In other words, the result of the method is void.
    void UpdateDiscrete()    {
        DateTime time = DateTime.Now;
        hoursTransform.localRotation =
            Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
        minutesTransform.localRotation =
            Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
        secondsTransform.localRotation =
            Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
    }

    void Update() {
        if(continuous) {
            UpdateContinuous();
        } else
        {
            UpdateDiscrete();
        }
    }
}