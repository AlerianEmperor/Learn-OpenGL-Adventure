#version 430 core

out vec4 FragColor;

in VS_OUT
{
	vec2 TexCoords;
} vs_out;

uniform sampler2D texture_diffuse;

void main()
{
	FragColor = texture(texture_diffuse, vs_out.TexCoords); 
}