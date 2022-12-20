#version 330 core
layout (location = 0) in vec3 Pos;
layout (location = 2) in vec2 TexCoords;

out vec2 tex;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    tex = TexCoords;    
    gl_Position = projection * view * model * vec4(Pos, 1.0);
}