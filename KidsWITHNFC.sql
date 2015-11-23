SELECT	kn.fldNFCCode,k.fldStudentID,k.fldNickName,k.fldFirstName,k.fldLastName,k.fldBirthday,s.fldStatus,
		(SELECT TOP 1 (fldFirstName + ' ' + fldLastName + ': #' + c.fldContactNumber) 
		FROM tblFetcher f 
		INNER JOIN tblKidFetcher kf ON kf.fldFetcherID=f.fldID 
		INNER JOIN tblContactDetails c ON c.fldID=f.fldContactDetails
		WHERE  kf.fldKidID=k.fldID) AS [Parent/Guardian]
FROM	tblKids k 
		LEFT JOIN tblKidsNFC kn ON kn.fldKidID=k.fldID
		LEFT JOIN tblStatus s ON s.fldID = k.fldUpdateStatus
		 
GROUP BY kn.fldNFCCode,k.fldStudentID,k.fldNickName,k.fldFirstName,k.fldLastName,k.fldBirthday,s.fldStatus,k.fldID
