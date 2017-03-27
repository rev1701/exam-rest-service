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
| Controller | HTTP Method | Endpoint | URI Params | Body Params| Result Set | Description
| --- | --- | --- | --- | --- | --- | ---| 
| ExamTemplate |	POST |	api/ExamTemplate |	none |	ExamTemplate | non |	CreateNew Exam Template
| ExamTemplate | 	PUT |	api/ExamTemplate/{id} | ExamTemplateID | ExamQuestionID | none | Add Question to Test
| ExamTemplate |	DELETE |	api/ExamTemplate/{id} |	ExamTemplateID | ExamTemplateID | none | none |	Delete ExamTemplate
| ExamTemplate |	GET |	api/ExamTemplate/{id} |	ExamTemplateID| none | Exam Template | Return Full Exam Template |
| ExamTemplate |	GET |	api/ExamTemplate/GetExamSubjects/{id} |	ExamTemplateID |	none | List of Subjects | Return All Subjects in an Examtemplate |
| ExamQuestion |	DELETE |	api/ExamQuestion/{ID} |	QuestionID |	None |	None |	delete question |
| ExamQuestion |	GET |	api/ExamQuestion/{id} |	questionID |	none |	ExamQuestion |	Return specific question |
| ExamQuestion |	GET |	api/ExamQuestion |	none |	none |	ListOfExamQuestions |	 return each question in database |
| ExamQuestion |	GET |	api/ExamQuestion/GetQuestionSubjects/{id} |	questionID |	none |	ListOFSubjects |	return all subjects in a question |
| ExamQuestion |	POST |	api/ExamQuestion/{id} |	QuestionID |	ExamQuestion |	None |	Create New Question |
| ExamQuestion |	PUT |	api/ExamQuestion/ChangeCorrectAnswer/{id} |	questionID |	Answer |	none |	Change Correct Answer |
| ExamQuestion |	PUT |	api/ExamQuestion/AddCategoryToQuestion/{id} |	questionID |	categoryID |	None |	add category to question |
| ExamQuestion |	PUT |	api/ExamQuestion/RemoveCategoryFromQuestion/{id} |	questionID |	categoryID |	None |	remove category from question |
| Answer |	POST |	api/Answer |	none |	Answer | none | create new answer |
| Answer |	GET |	api/Answer/{id} |	SubquestionId |	none | Answer |	get a specific answer
| Subquestion |	PUT |	api/Subquestion |	SubquestionId |	Subquestion | none | add answer to question |
| Subject |	POST |	api/Subject |	none |	Subject	 | none |	create new subject |
| Subject |	GET |	api/Subject |	none |	none | List of Subjects | return all subjects |
| Subject |	PUT |	api/AddCategory/{id} |	SubjectId |	Category | none | add category to subject |
| Subject |	PUT |	api/RemoveCategory/{id} |	SubjectId |	Category | none |		remove category from subject |
| Subject |	DELETE |	api/Subject/{id} |	SubjectId |	none | none		delete subtopic |
| Category |	POST |	api/Category |	SubjectId |	Category | none |		create new category |
| Category |	GET |	api/Category/{id} |	none |	none | List of Categories |		return all categories |
| Category |	PUT |	api/Category/AddSubtopic/{id} |	CategoryId |	subtopic | none | add subtopic to category |
| Category |	DELETE |	api/Category/{id} |	CategoryId	none | none |		delete category |
| Category |	PUT |	api/Category/RemoveSubtopic/{id} |	CategoryId |	subtopic| none		remove subtopic from category |
| Subtopic |	POST |	api/Subtopic/{id} |	CategoryId |	subtopic | none |	Subtopic and Category attached to	create new subtopic |
| Subtopic |	GET |	api/Subtopic |	none |	none |	List of Subtopics |	return all subtopics |
| Subtopic |	DELETE |	api/Subtopic/{id} |	int SubtopicId |	none |	Subtopic that was deleted | delete subtopic |
---
# license
Apache 2.0 (https://github.com/rev1701/exam-rest-service/blob/master/LICENSE)

---
# coda
</>
