#version 430 core

layout (location = 0) in vec2 pos;
layout (location = 1) in vec3 color;
layout (location = 2) in vec2 offset;

out vec3 Fcolor;

void main()
{
	Fcolor = color;

	gl_Position = vec4(pos + offset, 0.0f, 1.0f);
}
