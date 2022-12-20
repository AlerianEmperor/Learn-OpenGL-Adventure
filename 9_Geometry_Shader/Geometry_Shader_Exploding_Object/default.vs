#version 430 core

layout (location = 0) in vec3 pos;
layout (location = 2) in vec2 tex;

out VS_OUT
{
	vec2 TexCoords;
} vs_out;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
	vs_out.TexCoords = tex;
	gl_Position = projection * view * model * vec4(pos, 1.0f);
}