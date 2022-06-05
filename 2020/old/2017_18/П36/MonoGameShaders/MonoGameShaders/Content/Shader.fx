// текстура
sampler TextureSampler : register(s0);

float LightPower;
float Phase;

// функция для осветления картинки
// 1-й параметр - цвет (R,G,B, Alpha)
// 2-й параметр - координаты точки в текстуре
float4 PixelShaderLighter(float4 pos : SV_POSITION, float4 color1 : COLOR0, float2 texCoord : TEXCOORD0) : SV_TARGET0
{
	float4 tex = tex2D(TextureSampler, texCoord) * LightPower;
	return tex;
}

// Функция искажения картинки (волнообразное)
float4 PixelShaderWave(float4 pos : SV_POSITION, float4 color1 : COLOR0, float2 texCoord : TEXCOORD0) : SV_TARGET0
{
	texCoord.y = texCoord.y + (0.05)*(sin(texCoord.x * 20 + Phase * 10));
float4 tex = tex2D(TextureSampler, texCoord);
return tex;
}

// компиляция ФУНКЦИИ
technique Lighter
{
	pass Pass1 { // один проход
		PixelShader = compile ps_4_0_level_9_1 PixelShaderLighter();
	}
}

// компиляция ФУНКЦИИ
technique Wave
{
	pass Pass1 { // один проход
		PixelShader = compile ps_4_0_level_9_1 PixelShaderWave();
	}
}