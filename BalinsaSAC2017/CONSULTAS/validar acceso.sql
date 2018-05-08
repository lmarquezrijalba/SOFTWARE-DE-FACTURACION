SELECT U.USU_Codigo, U.USU_Login, U.USU_Contrasena, U.USU_Nombres, U.USU_Activo, NU.NUSU_Descripcion 
FROM tb_usuarios U, tb_niv_usuarios NU 
WHERE U.NUSU_Codigo = NU.NUSU_Codigo AND 
U.USU_Login = 'admin' AND 
U.USU_Contrasena='1234'