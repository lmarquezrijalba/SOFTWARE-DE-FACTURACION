SELECT CLI_Codigo, CLI_RazonSocial, CLI_RUC, CLI_Ciudad, CLI_Direccion
FROM tb_clientes 
WHERE CLI_RazonSocial LIKE '%LI%'


SELECT CLI_Codigo, CLI_RazonSocial, CLI_RUC, CLI_Direccion
FROM tb_clientes 
WHERE CLI_Codigo='C0000001'