# Fractal Shader

A Unity Fractal explorer based on Mandelbrot set. Options to navigate using WASD(QE) or set it up to use Arduino controls. 

Currently still a work in progress in terms of my hardware set up here in person. Base setup currently has two basic buttons. If possible, I'll use conductive paint in the future but seeing what I can do with what I have here instead. 

## About the Shader

This shader modifies the traditional Mandelbrot set equation to create a dynamic & interactive fractal exploration experience :) 

The classic Mandelbrot set equation is z = z^2 + c, where z and c are complex numbers. I modified the equation to z = rotate(z, 0, _Time.y) + c, where the value of z is  passed through a function "rotate" first. This function applies a rotation to the point, and then the resulting value of z is added to c. This modification causes the Mandelbrot set to rotate over time, as the rotation angle is controlled by the _Time.y variable.

The equation is used to calculate the position of each pixel on the canvas, and the resulting value is used to determine the color of the pixel. I thought fragment shaders were so exciting for this because they allow such precise dictation of the behavior of individual pixels. 

In the fragment shader, the current position of the pixel is calculated and then passed through the Mandelbrot equation, which calculates the distance of the pixel from the origin of the fractal. This distance is then used to determine the color of the pixel. The loop breaks out when the distance exceeds a certain threshold, known as the escape radius. This creates the characteristic shape of the Mandelbrot set.

This is not an infinite generation of fractals! It's limited and finite <3 
