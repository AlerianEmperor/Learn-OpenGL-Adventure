#version 430 core

out vec4 Fragcolor;

in VS_OUT
{
	vec3 FragPos;
	vec3 Normal;
	vec2 TexCoords;
	vec4 FragPosLightSpace;
} fs_in;

//uniform sampler2D DepthMap;
uniform float near_plane;
uniform float far_plane;

uniform sampler2D DiffuseTexture;
uniform sampler2D ShadowMap;

uniform vec3 LightPos;
uniform vec3 viewPos;

// required when using a perspective projection matrix
float LinearizeDepth(float depth)
{
    float z = depth * 2.0 - 1.0; // Back to NDC 
    return (2.0 * near_plane * far_plane) / (far_plane + near_plane - z * (far_plane - near_plane));	
}

float ShadowCalculation(vec4 FragPosLightSpace, vec3 Light_Direction)
{
	//trong gl_Position da lam luon hai buoc chuyen qua ndc va quy ve 0, 1
	//vi o day ko co nen ko can 2 buoc do
	vec3 projCoords = FragPosLightSpace.xyz / FragPosLightSpace.w;

	projCoords = 0.5f * projCoords + 0.5f;

	//projCoords.z = LinearizeDepth(projCoords.z);

	if(projCoords.z > 1.0f)
		return 0.0f;

	float closestDepth = texture(ShadowMap, projCoords.xy).r;// ko xai r

	float currentDepth = projCoords.z;
	
	//float bias = 0.005;

	float bias = max(0.009f * (1.0f - dot(Light_Direction, fs_in.Normal)), 0.009f);

	float shadow = currentDepth - bias >= closestDepth ? 1.0 : 0.0;

	

	return shadow;
}

float pcf(vec4 FragPosLightSpace, vec3 Light_Direction)
{
	vec3 projCoords = FragPosLightSpace.xyz / FragPosLightSpace.w;

	projCoords = 0.5f * projCoords + 0.5f;

	if(projCoords.z > 1.0f)
		return 0.0f;

	vec2 texelSize = 1.0f / textureSize(ShadowMap, 0);

	float shadow = 0.0f;

	//float closestDepth = texture(ShadowMap, projCoords.xy).r;

	float bias = max(0.03f * (1.0f - dot(Light_Direction, fs_in.Normal)), 0.03f);

	float currentDepth = projCoords.z;

	int d = 1;
	for(int x = -d; x <= d; ++x)
	{
		for(int y = -d; y <= d; ++y)
		{
			float pcfDepth = texture(ShadowMap, projCoords.xy + vec2(x, y) * texelSize).r;
			shadow += currentDepth - bias > pcfDepth ? 1.0f : 0.0f;
		}
	}

	return shadow / 9.0f;
}

void main()
{
	/*vec3 color = texture(DiffuseTexture, fs_in.TexCoords).rgb;
	vec3 normal = normalize(fs_in.Normal);

	vec3 Light_Direction = normalize(LightPos - fs_in.FragPos);
	vec3 View_Direction = normalize(viewPos - fs_in.FragPos);
	
	vec3 Half_Vector = normalize(Light_Direction + View_Direction);

	vec3 Light_Color = vec3(0.3f);

	vec3 Ambient = 0.3f * Light_Color;

	vec3 Diffuse = max(dot(Light_Direction, normal), 0.0f) * Light_Color;

	vec3 Specular = pow(max(dot(normal, Half_Vector), 0.0f), 64.0f) * Light_Color;

	//float shadow = ShadowCalculation(fs_in.FragPosLightSpace);

	float shadow = ShadowCalculation(fs_in.FragPosLightSpace);

	vec3 lighting = (Ambient + (1 - shadow) * (Diffuse + Specular)) * color;

	Fragcolor = vec4(lighting, 1.0f);*/

	vec3 color = texture(DiffuseTexture, fs_in.TexCoords).rgb;
    vec3 normal = fs_in.Normal;//normalize(fs_in.Normal);
    vec3 lightColor = vec3(0.3);
    // ambient
    vec3 ambient = 0.3 * lightColor;
    // diffuse
    vec3 lightDir = normalize(LightPos - fs_in.FragPos);
    float diff = max(dot(lightDir, normal), 0.0);
    vec3 diffuse = diff * lightColor;
    // specular
    vec3 viewDir = normalize(viewPos - fs_in.FragPos);
    //vec3 reflectDir = reflect(-lightDir, normal);
    //float spec = 0.0;
    vec3 halfwayDir = normalize(lightDir + viewDir);  
    float spec = pow(max(dot(normal, halfwayDir), 0.0), 64.0);
    vec3 specular = spec * lightColor;    
    // calculate shadow
    //float shadow = ShadowCalculation(fs_in.FragPosLightSpace, lightDir);                      
    float shadow = pcf(fs_in.FragPosLightSpace, lightDir);

	vec3 lighting = (ambient + (1.0 - shadow) * (diffuse + specular)) * color;    
    
    Fragcolor = vec4(lighting, 1.0);
	 
}