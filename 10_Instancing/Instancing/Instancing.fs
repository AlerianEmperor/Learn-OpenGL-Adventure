#version 430 core

out vec4 FragColor;

in vec3 Fcolor;

void main()
{
	FragColor = vec4(Fcolor, 1.0f);
}