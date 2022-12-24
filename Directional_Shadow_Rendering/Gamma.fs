#version 430 core

out vec4 FragColor;

in VS_OUT {
    vec3 FragPos;
    vec3 Normal;
    vec2 TexCoords;
} fs_in;

uniform sampler2D tex2d;
uniform vec3 lightPos[4];
uniform vec3 lightColor[4];
uniform vec3 viewPos;

uniform bool blinn;
uniform bool gamma;


vec3 blin_phong(vec3 normal, vec3 lightPos, vec3 fragPos, vec3 lightColor)
{
	vec3 light_direction = normalize(lightPos - fragPos);
	
	vec3 Diffuse = max(dot(light_direction, normal), 0.0f) * lightColor;

	vec3 view_direction = normalize(viewPos - fragPos);
	vec3 reflect_direction = reflect(-light_direction, normal);
	vec3 half_vector = normalize(light_direction + view_direction);

	vec3 Specular = pow(max(dot(normal, half_vector), 0.0f), 64.0f) * lightColor;

	float max_distance = 1.5f;
	
	float distance = length(lightPos - fragPos);

	float attenuate = 1.0f / (gamma ? distance * distance : distance);

	return (Diffuse + Specular) * attenuate;

}


void main()
{
	/*vec3 color = texture(tex2d, fs_in.TexCoords).rgb;

	vec3 ambient = 0.05 * color;

	vec3 normal = normalize(fs_in.Normal);

	vec3 view_direction = normalize(viewPos - fs_in.FragPos);



	vec3 light_direction = normalize(lightPos - fs_in.FragPos);
	

	float diff = max(dot(light_direction, normal), 0.0);
    vec3 diffuse = diff * color;

	float spec = 0.0f;

	if(blinn)
	{
		vec3 half_vector = normalize(light_direction + view_direction);
		spec = pow(max(dot(half_vector, view_direction), 0.0f), 32.0f);
	}
	else
	{
		vec3 reflectDir = reflect(-light_direction, normal);
		spec = pow(max(dot(reflectDir, view_direction), 0.0f), 8.0f);
	}
	vec3 specular = vec3(0.3) * spec;

	//FragColor = vec4(ambient + diffuse + specular, 1.0f);

	vec3 color = ambient + diffuse + specular;*/


	
	vec3 color = texture(tex2d, fs_in.TexCoords).rgb;

	vec3 light = vec3(0.0f);

	vec3 normal = normalize(fs_in.Normal);

	for(int i = 0; i < 4; ++i)
		light += blin_phong(normal, lightPos[i], fs_in.FragPos, lightColor[i]);
	
	color *= light;

	if(gamma)
		color = pow(color, vec3(1.0f / 2.2f));

	FragColor = vec4(color, 1.0f);

	//FragColor = vec4(0.0f);

}