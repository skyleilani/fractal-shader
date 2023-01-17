using UnityEngine;
using System.IO.Ports; 

public class Explorer : MonoBehaviour
{
    // SerialPort object to handle communication with an external device
    //static SerialPort sp = new SerialPort(); 


    public Material mat; // material object holding fractal shader

    public Vector2 pos; // position of fractal on canvas
    private Vector2 smoothPos; // smoothed position of fractal on canvas 

    public float scale, angle; // scale & angle of fractal 
    private float smoothScale, smoothAngle; // smoothed scale and angle of fractal 

    /* uncomment content for use with Arduino */
    private void Start()
    {
          // Open serial port connection 
          //  sp.Open();
          // Set a timeout for reading data from serial port 
         //  sp.ReadTimeout = 1;  
    }

    // Method to handle user input 
    private void UserInput()
    {
      /* Uncomment conditional statement for use with Arduino */
       // if (sp.IsOpen)
       // {
            // Calculate sine and cosine of rotation angle
            float s = Mathf.Sin(angle);
            float c = Mathf.Cos(angle);

        /* Uncomment for use with Arduino */
         /* 
            // Read bytes from arduino 
           try
           {
                if (sp.ReadByte() == 1)
                {
                    //reduce scale by 1% each time
                    scale *= .99f;
                    Debug.Log(sp.ReadByte());
                }

                else if (sp.ReadByte() == 2)
                {
                    scale *= 1.01f;

                    Debug.Log(sp.ReadByte());
                } 
        */
                
                // Increase scale by 1% each time 'w' is pressed
                if (Input.GetKey("w"))
                     scale /= 1.01f;

                 // Decrease scale by 1% each time 's' is pressed 
                 if (Input.GetKey("s"))
                     scale *= 1.01f;

                 // Move fractal right by .002 times the scale each time 'd' is pressed
                if (Input.GetKey("d"))
                    pos.x += .002f * scale;

                // Rotate fractal clockwise by .01 each time 'e' is pressed
                if (Input.GetKey("e"))
                    angle += .01f;

                // Rotate fractal counter-clockwise by .01 each time 'q' is pressed 
                if (Input.GetKey("q"))
                    angle -= .01f;
           
           // catch (System.Exception) { } } 
        
    }

    // Method to update values on fractal shader
    private void UpdateShader()
    {

        // Interpolate bentween current and target position, scale, and angle
        smoothPos = Vector2.Lerp(smoothPos, pos, 0.03f);
        smoothScale = Mathf.Lerp(smoothScale, scale, 0.03f);
        smoothAngle = Mathf.Lerp(smoothAngle, angle, 0.03f);

        // Adjust the scale of the fractal to match the aspect ratio off the screen 
        float aspect = (float)Screen.width / (float)Screen.height;
        float scaleX = smoothScale;
        float scaleY = smoothScale;

        // If aspect ratio is larger than 1, adjust the Y scale to match aspect ratio  
        if (aspect > 1f)
            scaleY /= aspect;

        // If aspect ratio is less than 1, adjust the X scale to match the aspect ratio 
        else
            scaleX *= aspect;
        // sets _Area vector4(x, y , z, w ) 
        // pos.x - x component of Vector2 ; pos.y - y component of Vector2 
        mat.SetVector("_Area", new Vector4(pos.x, pos.y, scaleX, scaleY)); // setting _Area vector4 (x, y, z, w) 
       
        // sets the interp_Angle float 
        mat.SetFloat("_Angle", smoothAngle);
    }

    void FixedUpdate()
    {
        UserInput(); 
        UpdateShader();
    }
}
