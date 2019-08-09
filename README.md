Documentation Author: Alexander Amling

# Unity Instanced Rendering
*Unity Compute Shaders Part 1*

The aim of instanced rendering is to reduce the number of draw calls by rendering all of the copies of a single mesh at the same time, each with their own respective transform.

At its simplest, instanced rendering in Unity is fairly straightforward. The function Graphics.DrawMeshInstanced() Calls for a fairly simple list of parameters: 

    - Any mesh, 
    - The index of the submesh (which for our needs is 0), 
    - A material to use (any material with "Enable GPU Instancing" checked works)
    - An array of 4x4 Matrix transforms
    - A count of the instances we are rendering

Our code calls a simple method GenerateTransforms() to populate the matrix array with random positions rotations and scales, then makes the render each update.

One of the limitations of DrawMeshInstanced is that modifying the transform matricies in their current state is rather innefecient, and this will be addressed in part 3. In Part 2, we will adress the main issue with DrawMeshInstanced; there is a maximum of 1023 instances that can be drawn in one call.
