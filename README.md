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
                                                 EXAM TEMPLATE 
 |	POST |	api/ExamTemplate/AddExam |	none |	ExamTemplate | non |	CreateNew Exam Template
 | 	PUT |	api/ExamTemplate/AddQuestionToExam?extid={id}&weight={weight} | ExamTemplateID, Weight | ExamQuestionID | none | Add Question to Test
 |	DELETE |	api/ExamTemplate/{id} |	ExamTemplateID | none | none |	Delete ExamTemplate
 |	GET |	api/ExamTemplate/GetExam?id={id} |	ExamTemplateID| none | Exam Template | Return Full Exam Template |
 |	GET |	api/ExamTemplate/GetExamSubjects?id={id} |	ExamTemplateID |	none | List of Subjects | Return All Subjects in an Exam Template |
                                                  EXAM QUESTION 
 |	DELETE |	api/ExamQuestion/{ID} |	QuestionID |	None |	None |	delete question |
 |	GET |	api/ExamQuestion/{id} |	questionID |	none |	ExamQuestion |	Return specific question |
 | GET | api/ExamQuestion/GetExamQuestionIDs | none | none| List of Exam Question IDs | Return list of all Exam Question IDs
 |	GET |	api/ExamQuestion/GetAllExamQuestions |	none |	none |	ListOfExamQuestions |	 return each question in database |
 |	GET |	api/ExamQuestion/GetSpecificQuestionSubjects?questionID={ExamQuestionID} |	ExamQuestionID |	none |	ListOFSubjects |	return all subjects in a question |
 |	POST |	api/ExamQuestion/{id} |	none |	ExamQuestion |	None |	Create New Question |
 |	PUT |	api/ExamQuestion/AddCategoryToQuestion/?questionID={ExamQuestionID}&categoryID={categoryID} |	questionID, categoryID | none |	HTTP Response Message |	add category to question |
 |	Delete |	api/ExamQuestion/RemoveCategoryFromQuestion/?questionID={ExamQuestionID}&categoryID={categoryID} |	questionID,categoryID |	|	none | HTTP Response Message |	remove category from question |
                                                   ANSWER
 |	POST |	api/Answer?QuestionID={QuestionID} |	QuestionID |	Answer | none | create new answer |
 |	GET |	api/Answer?SubquestionID={SubquestionID} |	SubquestionId |	none | Answer |	get a specific answer |
 | PUT | api/Answer?answerid={answerid} | answerid | answer | none | edit an answer |
                                                   SUBQUESTION
 | GET | api/Subquestion | none | none | List of subquestion | returns all the subquestions |
 |	PUT |	api/Subquestion?SubquestionId={SubquestionId} |	SubquestionId |	Answer | none | add answer to question |
                                                   SUBJECT
 |	POST |	api/Subject |	none |	SubjectName	 | none |	create new subject |
 |	GET |	api/Subject |	none |	none | List of Subjects | return all subjects |
 | POST | api/Subject/AddExistingCategory?SubjectName={SubjectName} | CategoryName | none | add an existing category to a existing subject |
 | DELETE | api/Subject?SubjectName={SubjectName} | SubjectName | none | none | deletes a subject |
 |	DELETE |	api/Subject/RemoveCategory/?CategoryName={CategoryName} |	CategoryName |	none | none |		remove category from subject |
                                                   CATEGORY
 |	POST |	api/Category | none | subjectName, CategoryName | none | add a brand new category attached to a subject
 |	GET |	api/Category/ |	none |	none | List of Categories |		return all categories |
 |	POST |	api/Category/AddNewSubtopic?CategoryName={CategoryName} |	CategoryName |	SubtopicName | none | add brand new subtopic to category |
 |	DELETE |	api/Category/?CategoryName={CategoryName}|	CategoryName |	none | none |		delete category |
 |	DELETE |	api/Category/RemoveSubtopic?|	CategoryId |	subtopic| none |		remove subtopic from category |
                                                   SUBTOPIC
 |	GET |	api/Subtopic |	none |	none |	List of Subtopics |	return all subtopics |
 |	DELETE |	api/Subtopic/SubtopicId={SubtopicId} |	SubtopicId |	none | none | delete subtopic |
---
# license
Apache 2.0 (https://github.com/rev1701/exam-rest-service/blob/master/LICENSE)

---
# coda
</>
