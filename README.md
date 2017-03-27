# Exam web service
REST web service to manage exams and questions.


---
# technologies
- ASP.NET
- Web API
- JSON
- C#


---
# team
(EA) Exam Assessment
- Devonte Holmes
- Paul Stanton
- Stephen Osei-Owusu
- Summer Wilkens

---
# EndPoints
 | HTTP Method | Endpoint | URI Params | Body Params| Result Set | Description
 | --- | --- | --- | --- | --- | ---| 
 |	POST |	api/ExamTemplate |	none |	ExamTemplate | non |	CreateNew Exam Template
 | 	PUT |	api/ExamTemplate/{id} | ExamTemplateID | ExamQuestionID | none | Add Question to Test
 |	DELETE |	api/ExamTemplate/{id} |	ExamTemplateID | ExamTemplateID | none | none |	Delete ExamTemplate
 |	GET |	api/ExamTemplate/{id} |	ExamTemplateID| none | Exam Template | Return Full Exam Template |
 |	GET |	api/ExamTemplate/GetExamSubjects/{id} |	ExamTemplateID |	none | List of Subjects | Return All Subjects in an Examtemplate |
 |	DELETE |	api/ExamQuestion/{ID} |	QuestionID |	None |	None |	delete question |
 |	GET |	api/ExamQuestion/{id} |	questionID |	none |	ExamQuestion |	Return specific question |
 |	GET |	api/ExamQuestion |	none |	none |	ListOfExamQuestions |	 return each question in database |
 |	GET |	api/ExamQuestion/GetQuestionSubjects/{id} |	questionID |	none |	ListOFSubjects |	return all subjects in a question |
 |	POST |	api/ExamQuestion/{id} |	QuestionID |	ExamQuestion |	None |	Create New Question |
 |	PUT |	api/ExamQuestion/ChangeCorrectAnswer/{id} |	questionID |	Answer |	none |	Change Correct Answer |
 |	PUT |	api/ExamQuestion/AddCategoryToQuestion/{id} |	questionID |	categoryID |	None |	add category to question |
 |	PUT |	api/ExamQuestion/RemoveCategoryFromQuestion/{id} |	questionID |	categoryID |	None |	remove category from question |
 |	POST |	api/Answer |	none |	Answer | none | create new answer |
 |	GET |	api/Answer/{id} |	SubquestionId |	none | Answer |	get a specific answer
 |	PUT |	api/Subquestion |	SubquestionId |	Subquestion | none | add answer to question |
 |	POST |	api/Subject |	none |	Subject	 | none |	create new subject |
 |	GET |	api/Subject |	none |	none | List of Subjects | return all subjects |
 |	PUT |	api/AddCategory/{id} |	SubjectId |	Category | none | add category to subject |
 |	PUT |	api/RemoveCategory/{id} |	SubjectId |	Category | none |		remove category from subject |
 |	DELETE |	api/Subject/{id} |	SubjectId |	none | none| 		delete subtopic |
 |	POST |	api/Category |	SubjectId |	Category | none |		create new category |
 |	GET |	api/Category/{id} |	none |	none | List of Categories |		return all categories |
 |	PUT |	api/Category/AddSubtopic/{id} |	CategoryId |	subtopic | none | add subtopic to category |
 |	DELETE |	api/Category/{id} |	CategoryId	none | none |		delete category |
 |	PUT |	api/Category/RemoveSubtopic/{id} |	CategoryId |	subtopic| none |		remove subtopic from category |
 |	POST |	api/Subtopic/{id} |	CategoryId |	subtopic | none | none |	Subtopic and Category attached to	create new subtopic |
 |	GET |	api/Subtopic |	none |	none |	List of Subtopics |	return all subtopics |
 |	DELETE |	api/Subtopic/{id} |	int SubtopicId |	none |	Subtopic that was deleted | delete subtopic |
---
# license
Apache 2.0 (https://github.com/rev1701/exam-rest-service/blob/master/LICENSE)

---
# coda
</>
