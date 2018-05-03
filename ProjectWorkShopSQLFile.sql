Select * From tbl_Role


Select * From tbl_User

Select tbl_User.UserId, tbl_User.FirstName, tbl_User.LastName FROM tbl_User 
                     INNER JOIN
		tbl_Role ON tbl_User.RoleId = tbl_Role.RoleId 
		WHERE (tbl_Role.RoleName = 'Trainer')




Select * From tbl_Trainer_WorkShop_Mapping