#version 430 core

in vec2 texcoord;

out vec4 FragColor;

uniform sampler2D texture_diffuse;

void main()
{
	FragColor = texture(texture_diffuse, texcoord);
}