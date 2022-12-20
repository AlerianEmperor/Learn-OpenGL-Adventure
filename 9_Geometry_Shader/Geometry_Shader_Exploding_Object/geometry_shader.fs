#version 430 core

out vec4 FragColor;

//in vec3 fColor;

in vec2 TexCoords;


uniform sampler2D texture_diffuse;

void main()
{
	//FragColor = vec4(fColor, 1.0f);
	FragColor = texture(texture_diffuse, TexCoords); 
	//FragColor = texture(texture_diffuse, vs_in.TexCoords); 
}