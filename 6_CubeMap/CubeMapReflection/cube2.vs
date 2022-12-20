#version 430 core

layout (location = 0) in vec3 position;
layout (location = 1) in vec3 normal;

out vec3 pos;
out vec3 norm;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
	pos = vec3(model * vec4(position, 1.0f));
	//norm = normal;
	norm = mat3(transpose(inverse(model))) * normal;

	gl_Position = projection * view * model * vec4(position, 1.0f);
}