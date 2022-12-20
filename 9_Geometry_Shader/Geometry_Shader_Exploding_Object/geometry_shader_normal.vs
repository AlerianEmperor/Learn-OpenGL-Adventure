#version 430 core

layout (location = 0) in vec3 pos;
layout (location = 1) in vec3 normal;

out VS_OUT
{
	vec3 normal;
} vs_out;

uniform mat4 model;
uniform mat4 view;

void main()
{
	gl_Position = view * model * vec4(pos, 1.0);

	//vs_out.normal = transpose(inverse(view * model));

	mat3 normalMatrix = mat3(transpose(inverse(view * model)));

	vs_out.normal = normalMatrix * normal;
}