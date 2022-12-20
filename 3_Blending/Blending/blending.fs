#version 430 core

in vec2 tex;
out vec4 frag_color;

uniform sampler2D texture_diffuse;

void main()
{
	vec4 color = texture(texture_diffuse, tex);

	//if(color.a < 0.1f)
	//	discard;

	frag_color = color;
}