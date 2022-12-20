#version 430 core

layout (location = 0) in vec3 pos;
layout (location = 1) in vec2 texcoord;

out vec2 tex;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
	tex = texcoord;

	gl_Position = projection * view * model * vec4(pos, 1.0f);
}