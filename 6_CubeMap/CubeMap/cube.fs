#version 430 core

in vec2 tex;
out vec4 frag_color;

uniform sampler2D texture1;

void main()
{
	//vec4 color = texture(texture1, tex);

	//if(color.a < 0.1f)
	//	discard;

	//frag_color = color;

	frag_color = texture(texture1, tex);
}