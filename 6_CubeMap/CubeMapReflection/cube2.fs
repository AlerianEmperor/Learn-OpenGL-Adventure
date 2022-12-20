#version 430 core

//in vec2 tex;

in vec3 pos;
in vec3 norm;

out vec4 frag_color;

uniform vec3 camera_pos;
uniform samplerCube SkyBox;

void main()
{
	//vec4 color = texture(texture1, tex);

	//if(color.a < 0.1f)
	//	discard;

	//frag_color = color;

	
	vec3 I = normalize(pos - camera_pos);
	//vec3 R = reflect(I, normalize(norm));

	float ratio = 1.0f / 1.52f;
	vec3 R = refract(I, normalize(norm), ratio);

	frag_color = texture(SkyBox, R);
	//frag_color = vec4(texture(SkyBox, R).rgb, 1.0);

	//frag_color = texture(texture1, tex);
}