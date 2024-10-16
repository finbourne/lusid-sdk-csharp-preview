/*
 * LUSID API
 *
 * # Introduction  This page documents the [LUSID APIs](../../../api/swagger), which allows authorised clients to query and update their data within the LUSID platform.  SDKs to interact with the LUSID APIs are available in the following languages and frameworks:  * [C#](https://github.com/finbourne/lusid-sdk-csharp) * [Java](https://github.com/finbourne/lusid-sdk-java) * [JavaScript](https://github.com/finbourne/lusid-sdk-js) * [Python](https://github.com/finbourne/lusid-sdk-python) * [Angular](https://github.com/finbourne/lusid-sdk-angular)  The LUSID platform is made up of a number of sub-applications. You can find the API / swagger documentation by following the links in the table below.   | Application   | Description                                                                       | API / Swagger Documentation                          | |- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | LUSID         | Open, API-first, developer-friendly investment data platform.                     | [Swagger](../../../api/swagger/index.html)           | | Web app       | User-facing front end for LUSID.                                                  | [Swagger](../../../app/swagger/index.html)           | | Scheduler     | Automated job scheduler.                                                          | [Swagger](../../../scheduler2/swagger/index.html)    | | Insights      | Monitoring and troubleshooting service.                                           | [Swagger](../../../insights/swagger/index.html)      | | Identity      | Identity management for LUSID (in conjunction with Access)                        | [Swagger](../../../identity/swagger/index.html)      | | Access        | Access control for LUSID (in conjunction with Identity)                           | [Swagger](../../../access/swagger/index.html)        | | Drive         | Secure file repository and manager for collaboration.                             | [Swagger](../../../drive/swagger/index.html)         | | Luminesce     | Data virtualisation service (query data from multiple providers, including LUSID) | [Swagger](../../../honeycomb/swagger/index.html)     | | Notification  | Notification service.                                                             | [Swagger](../../../notification/swagger/index.html)  | | Configuration | File store for secrets and other sensitive information.                           | [Swagger](../../../configuration/swagger/index.html) | | Workflow      | Workflow service.                                                                 | [Swagger](../../../workflow/swagger/index.html)      |   # Error Codes  | Code|Name|Description | | - --|- --|- -- | | <a name=\"-10\">-10</a>|Server Configuration Error|  | | <a name=\"-1\">-1</a>|Unknown error|An unexpected error was encountered on our side. | | <a name=\"102\">102</a>|Version Not Found|  | | <a name=\"103\">103</a>|Api Rate Limit Violation|  | | <a name=\"104\">104</a>|Instrument Not Found|  | | <a name=\"105\">105</a>|Property Not Found|  | | <a name=\"106\">106</a>|Portfolio Recursion Depth|  | | <a name=\"108\">108</a>|Group Not Found|  | | <a name=\"109\">109</a>|Portfolio Not Found|  | | <a name=\"110\">110</a>|Property Schema Not Found|  | | <a name=\"111\">111</a>|Portfolio Ancestry Not Found|  | | <a name=\"112\">112</a>|Portfolio With Id Already Exists|  | | <a name=\"113\">113</a>|Orphaned Portfolio|  | | <a name=\"119\">119</a>|Missing Base Claims|  | | <a name=\"121\">121</a>|Property Not Defined|  | | <a name=\"122\">122</a>|Cannot Delete System Property|  | | <a name=\"123\">123</a>|Cannot Modify Immutable Property Field|  | | <a name=\"124\">124</a>|Property Already Exists|  | | <a name=\"125\">125</a>|Invalid Property Life Time|  | | <a name=\"126\">126</a>|Property Constraint Style Excludes Properties|  | | <a name=\"127\">127</a>|Cannot Modify Default Data Type|  | | <a name=\"128\">128</a>|Group Already Exists|  | | <a name=\"129\">129</a>|No Such Data Type|  | | <a name=\"130\">130</a>|Undefined Value For Data Type|  | | <a name=\"131\">131</a>|Unsupported Value Type Defined On Data Type|  | | <a name=\"132\">132</a>|Validation Error|  | | <a name=\"133\">133</a>|Loop Detected In Group Hierarchy|  | | <a name=\"134\">134</a>|Undefined Acceptable Values|  | | <a name=\"135\">135</a>|Sub Group Already Exists|  | | <a name=\"138\">138</a>|Price Source Not Found|  | | <a name=\"139\">139</a>|Analytic Store Not Found|  | | <a name=\"141\">141</a>|Analytic Store Already Exists|  | | <a name=\"143\">143</a>|Client Instrument Already Exists|  | | <a name=\"144\">144</a>|Duplicate In Parameter Set|  | | <a name=\"147\">147</a>|Results Not Found|  | | <a name=\"148\">148</a>|Order Field Not In Result Set|  | | <a name=\"149\">149</a>|Operation Failed|  | | <a name=\"150\">150</a>|Elastic Search Error|  | | <a name=\"151\">151</a>|Invalid Parameter Value|  | | <a name=\"153\">153</a>|Command Processing Failure|  | | <a name=\"154\">154</a>|Entity State Construction Failure|  | | <a name=\"155\">155</a>|Entity Timeline Does Not Exist|  | | <a name=\"156\">156</a>|Concurrency Conflict Failure|  | | <a name=\"157\">157</a>|Invalid Request|  | | <a name=\"158\">158</a>|Event Publish Unknown|  | | <a name=\"159\">159</a>|Event Query Failure|  | | <a name=\"160\">160</a>|Blob Did Not Exist|  | | <a name=\"162\">162</a>|Sub System Request Failure|  | | <a name=\"163\">163</a>|Sub System Configuration Failure|  | | <a name=\"165\">165</a>|Failed To Delete|  | | <a name=\"166\">166</a>|Upsert Client Instrument Failure|  | | <a name=\"167\">167</a>|Illegal As At Interval|  | | <a name=\"168\">168</a>|Illegal Bitemporal Query|  | | <a name=\"169\">169</a>|Invalid Alternate Id|  | | <a name=\"170\">170</a>|Cannot Add Non-Writable Properties To Entity|  | | <a name=\"171\">171</a>|Entity Already Exists In Group|  | | <a name=\"172\">172</a>|Entity With Id Does Not Exist|  | | <a name=\"173\">173</a>|Entity With Id Already Exists|  | | <a name=\"174\">174</a>|Derived Portfolio Details Do Not Exist|  | | <a name=\"175\">175</a>|Entity Not In Group|  | | <a name=\"176\">176</a>|Portfolio With Name Already Exists|  | | <a name=\"177\">177</a>|Invalid Transactions|  | | <a name=\"178\">178</a>|Reference Portfolio Not Found|  | | <a name=\"179\">179</a>|Duplicate Id|  | | <a name=\"180\">180</a>|Command Retrieval Failure|  | | <a name=\"181\">181</a>|Data Filter Application Failure|  | | <a name=\"182\">182</a>|Search Failed|  | | <a name=\"183\">183</a>|Movements Engine Configuration Key Failure|  | | <a name=\"184\">184</a>|Fx Rate Source Not Found|  | | <a name=\"185\">185</a>|Accrual Source Not Found|  | | <a name=\"186\">186</a>|Access Denied|  | | <a name=\"187\">187</a>|Invalid Identity Token|  | | <a name=\"188\">188</a>|Invalid Request Headers|  | | <a name=\"189\">189</a>|Price Not Found|  | | <a name=\"190\">190</a>|Invalid Sub Holding Keys Provided|  | | <a name=\"191\">191</a>|Duplicate Sub Holding Keys Provided|  | | <a name=\"192\">192</a>|Cut Definition Not Found|  | | <a name=\"193\">193</a>|Cut Definition Invalid|  | | <a name=\"194\">194</a>|Time Variant Property Deletion Date Unspecified|  | | <a name=\"195\">195</a>|Perpetual Property Deletion Date Specified|  | | <a name=\"196\">196</a>|Time Variant Property Upsert Date Unspecified|  | | <a name=\"197\">197</a>|Perpetual Property Upsert Date Specified|  | | <a name=\"200\">200</a>|Invalid Unit For Data Type|  | | <a name=\"201\">201</a>|Invalid Type For Data Type|  | | <a name=\"202\">202</a>|Invalid Value For Data Type|  | | <a name=\"203\">203</a>|Unit Not Defined For Data Type|  | | <a name=\"204\">204</a>|Units Not Supported On Data Type|  | | <a name=\"205\">205</a>|Cannot Specify Units On Data Type|  | | <a name=\"206\">206</a>|Unit Schema Inconsistent With Data Type|  | | <a name=\"207\">207</a>|Unit Definition Not Specified|  | | <a name=\"208\">208</a>|Duplicate Unit Definitions Specified|  | | <a name=\"209\">209</a>|Invalid Units Definition|  | | <a name=\"210\">210</a>|Invalid Instrument Identifier Unit|  | | <a name=\"211\">211</a>|Holdings Adjustment Does Not Exist|  | | <a name=\"212\">212</a>|Could Not Build Excel Url|  | | <a name=\"213\">213</a>|Could Not Get Excel Version|  | | <a name=\"214\">214</a>|Instrument By Code Not Found|  | | <a name=\"215\">215</a>|Entity Schema Does Not Exist|  | | <a name=\"216\">216</a>|Feature Not Supported On Portfolio Type|  | | <a name=\"217\">217</a>|Quote Not Found|  | | <a name=\"218\">218</a>|Invalid Quote Identifier|  | | <a name=\"219\">219</a>|Invalid Metric For Data Type|  | | <a name=\"220\">220</a>|Invalid Instrument Definition|  | | <a name=\"221\">221</a>|Instrument Upsert Failure|  | | <a name=\"222\">222</a>|Reference Portfolio Request Not Supported|  | | <a name=\"223\">223</a>|Transaction Portfolio Request Not Supported|  | | <a name=\"224\">224</a>|Invalid Property Value Assignment|  | | <a name=\"230\">230</a>|Transaction Type Not Found|  | | <a name=\"231\">231</a>|Transaction Type Duplication|  | | <a name=\"232\">232</a>|Portfolio Does Not Exist At Given Date|  | | <a name=\"233\">233</a>|Query Parser Failure|  | | <a name=\"234\">234</a>|Duplicate Constituent|  | | <a name=\"235\">235</a>|Unresolved Instrument Constituent|  | | <a name=\"236\">236</a>|Unresolved Instrument In Transition|  | | <a name=\"237\">237</a>|Missing Side Definitions|  | | <a name=\"240\">240</a>|Duplicate Calculations Failure|  | | <a name=\"299\">299</a>|Invalid Recipe|  | | <a name=\"300\">300</a>|Missing Recipe|  | | <a name=\"301\">301</a>|Dependencies|  | | <a name=\"304\">304</a>|Portfolio Preprocess Failure|  | | <a name=\"310\">310</a>|Valuation Engine Failure|  | | <a name=\"311\">311</a>|Task Factory Failure|  | | <a name=\"312\">312</a>|Task Evaluation Failure|  | | <a name=\"313\">313</a>|Task Generation Failure|  | | <a name=\"314\">314</a>|Engine Configuration Failure|  | | <a name=\"315\">315</a>|Model Specification Failure|  | | <a name=\"320\">320</a>|Market Data Key Failure|  | | <a name=\"321\">321</a>|Market Resolver Failure|  | | <a name=\"322\">322</a>|Market Data Failure|  | | <a name=\"330\">330</a>|Curve Failure|  | | <a name=\"331\">331</a>|Volatility Surface Failure|  | | <a name=\"332\">332</a>|Volatility Cube Failure|  | | <a name=\"350\">350</a>|Instrument Failure|  | | <a name=\"351\">351</a>|Cash Flows Failure|  | | <a name=\"352\">352</a>|Reference Data Failure|  | | <a name=\"360\">360</a>|Aggregation Failure|  | | <a name=\"361\">361</a>|Aggregation Measure Failure|  | | <a name=\"370\">370</a>|Result Retrieval Failure|  | | <a name=\"371\">371</a>|Result Processing Failure|  | | <a name=\"372\">372</a>|Vendor Result Processing Failure|  | | <a name=\"373\">373</a>|Vendor Result Mapping Failure|  | | <a name=\"374\">374</a>|Vendor Library Unauthorised|  | | <a name=\"375\">375</a>|Vendor Connectivity Error|  | | <a name=\"376\">376</a>|Vendor Interface Error|  | | <a name=\"377\">377</a>|Vendor Pricing Failure|  | | <a name=\"378\">378</a>|Vendor Translation Failure|  | | <a name=\"379\">379</a>|Vendor Key Mapping Failure|  | | <a name=\"380\">380</a>|Vendor Reflection Failure|  | | <a name=\"381\">381</a>|Vendor Process Failure|  | | <a name=\"382\">382</a>|Vendor System Failure|  | | <a name=\"390\">390</a>|Attempt To Upsert Duplicate Quotes|  | | <a name=\"391\">391</a>|Corporate Action Source Does Not Exist|  | | <a name=\"392\">392</a>|Corporate Action Source Already Exists|  | | <a name=\"393\">393</a>|Instrument Identifier Already In Use|  | | <a name=\"394\">394</a>|Properties Not Found|  | | <a name=\"395\">395</a>|Batch Operation Aborted|  | | <a name=\"400\">400</a>|Invalid Iso4217 Currency Code|  | | <a name=\"401\">401</a>|Cannot Assign Instrument Identifier To Currency|  | | <a name=\"402\">402</a>|Cannot Assign Currency Identifier To Non Currency|  | | <a name=\"403\">403</a>|Currency Instrument Cannot Be Deleted|  | | <a name=\"404\">404</a>|Currency Instrument Cannot Have Economic Definition|  | | <a name=\"405\">405</a>|Currency Instrument Cannot Have Lookthrough Portfolio|  | | <a name=\"406\">406</a>|Cannot Create Currency Instrument With Multiple Identifiers|  | | <a name=\"407\">407</a>|Specified Currency Is Undefined|  | | <a name=\"410\">410</a>|Index Does Not Exist|  | | <a name=\"411\">411</a>|Sort Field Does Not Exist|  | | <a name=\"413\">413</a>|Negative Pagination Parameters|  | | <a name=\"414\">414</a>|Invalid Search Syntax|  | | <a name=\"415\">415</a>|Filter Execution Timeout|  | | <a name=\"420\">420</a>|Side Definition Inconsistent|  | | <a name=\"450\">450</a>|Invalid Quote Access Metadata Rule|  | | <a name=\"451\">451</a>|Access Metadata Not Found|  | | <a name=\"452\">452</a>|Invalid Access Metadata Identifier|  | | <a name=\"460\">460</a>|Standard Resource Not Found|  | | <a name=\"461\">461</a>|Standard Resource Conflict|  | | <a name=\"462\">462</a>|Calendar Not Found|  | | <a name=\"463\">463</a>|Date In A Calendar Not Found|  | | <a name=\"464\">464</a>|Invalid Date Source Data|  | | <a name=\"465\">465</a>|Invalid Timezone|  | | <a name=\"601\">601</a>|Person Identifier Already In Use|  | | <a name=\"602\">602</a>|Person Not Found|  | | <a name=\"603\">603</a>|Cannot Set Identifier|  | | <a name=\"617\">617</a>|Invalid Recipe Specification In Request|  | | <a name=\"618\">618</a>|Inline Recipe Deserialisation Failure|  | | <a name=\"619\">619</a>|Identifier Types Not Set For Entity|  | | <a name=\"620\">620</a>|Cannot Delete All Client Defined Identifiers|  | | <a name=\"650\">650</a>|The Order requested was not found.|  | | <a name=\"654\">654</a>|The Allocation requested was not found.|  | | <a name=\"655\">655</a>|Cannot build the fx forward target with the given holdings.|  | | <a name=\"656\">656</a>|Group does not contain expected entities.|  | | <a name=\"665\">665</a>|Destination directory not found|  | | <a name=\"667\">667</a>|Relation definition already exists|  | | <a name=\"672\">672</a>|Could not retrieve file contents|  | | <a name=\"673\">673</a>|Missing entitlements for entities in Group|  | | <a name=\"674\">674</a>|Next Best Action not found|  | | <a name=\"676\">676</a>|Relation definition not defined|  | | <a name=\"677\">677</a>|Invalid entity identifier for relation|  | | <a name=\"681\">681</a>|Sorting by specified field not supported|One or more of the provided fields to order by were either invalid or not supported. | | <a name=\"682\">682</a>|Too many fields to sort by|The number of fields to sort the data by exceeds the number allowed by the endpoint | | <a name=\"684\">684</a>|Sequence Not Found|  | | <a name=\"685\">685</a>|Sequence Already Exists|  | | <a name=\"686\">686</a>|Non-cycling sequence has been exhausted|  | | <a name=\"687\">687</a>|Legal Entity Identifier Already In Use|  | | <a name=\"688\">688</a>|Legal Entity Not Found|  | | <a name=\"689\">689</a>|The supplied pagination token is invalid|  | | <a name=\"690\">690</a>|Property Type Is Not Supported|  | | <a name=\"691\">691</a>|Multiple Tax-lots For Currency Type Is Not Supported|  | | <a name=\"692\">692</a>|This endpoint does not support impersonation|  | | <a name=\"693\">693</a>|Entity type is not supported for Relationship|  | | <a name=\"694\">694</a>|Relationship Validation Failure|  | | <a name=\"695\">695</a>|Relationship Not Found|  | | <a name=\"697\">697</a>|Derived Property Formula No Longer Valid|  | | <a name=\"698\">698</a>|Story is not available|  | | <a name=\"703\">703</a>|Corporate Action Does Not Exist|  | | <a name=\"720\">720</a>|The provided sort and filter combination is not valid|  | | <a name=\"721\">721</a>|A2B generation failed|  | | <a name=\"722\">722</a>|Aggregated Return Calculation Failure|  | | <a name=\"723\">723</a>|Custom Entity Definition Identifier Already In Use|  | | <a name=\"724\">724</a>|Custom Entity Definition Not Found|  | | <a name=\"725\">725</a>|The Placement requested was not found.|  | | <a name=\"726\">726</a>|The Execution requested was not found.|  | | <a name=\"727\">727</a>|The Block requested was not found.|  | | <a name=\"728\">728</a>|The Participation requested was not found.|  | | <a name=\"729\">729</a>|The Package requested was not found.|  | | <a name=\"730\">730</a>|The OrderInstruction requested was not found.|  | | <a name=\"732\">732</a>|Custom Entity not found.|  | | <a name=\"733\">733</a>|Custom Entity Identifier already in use.|  | | <a name=\"735\">735</a>|Calculation Failed.|  | | <a name=\"736\">736</a>|An expected key on HttpResponse is missing.|  | | <a name=\"737\">737</a>|A required fee detail is missing.|  | | <a name=\"738\">738</a>|Zero rows were returned from Luminesce|  | | <a name=\"739\">739</a>|Provided Weekend Mask was invalid|  | | <a name=\"742\">742</a>|Custom Entity fields do not match the definition|  | | <a name=\"746\">746</a>|The provided sequence is not valid.|  | | <a name=\"751\">751</a>|The type of the Custom Entity is different than the type provided in the definition.|  | | <a name=\"752\">752</a>|Luminesce process returned an error.|  | | <a name=\"753\">753</a>|File name or content incompatible with operation.|  | | <a name=\"755\">755</a>|Schema of response from Drive is not as expected.|  | | <a name=\"757\">757</a>|Schema of response from Luminesce is not as expected.|  | | <a name=\"758\">758</a>|Luminesce timed out.|  | | <a name=\"763\">763</a>|Invalid Lusid Entity Identifier Unit|  | | <a name=\"768\">768</a>|Fee rule not found.|  | | <a name=\"769\">769</a>|Cannot update the base currency of a portfolio with transactions loaded|  | | <a name=\"771\">771</a>|Transaction configuration source not found|  | | <a name=\"774\">774</a>|Compliance rule not found.|  | | <a name=\"775\">775</a>|Fund accounting document cannot be processed.|  | | <a name=\"778\">778</a>|Unable to look up FX rate from trade ccy to portfolio ccy for some of the trades.|  | | <a name=\"782\">782</a>|The Property definition dataType is not matching the derivation formula dataType|  | | <a name=\"783\">783</a>|The Property definition domain is not supported for derived properties|  | | <a name=\"788\">788</a>|Compliance run not found failure.|  | | <a name=\"790\">790</a>|Custom Entity has missing or invalid identifiers|  | | <a name=\"791\">791</a>|Custom Entity definition already exists|  | | <a name=\"792\">792</a>|Compliance PropertyKey is missing.|  | | <a name=\"793\">793</a>|Compliance Criteria Value for matching is missing.|  | | <a name=\"795\">795</a>|Cannot delete identifier definition|  | | <a name=\"796\">796</a>|Tax rule set not found.|  | | <a name=\"797\">797</a>|A tax rule set with this id already exists.|  | | <a name=\"798\">798</a>|Multiple rule sets for the same property key are applicable.|  | | <a name=\"799\">799</a>|The request must contain a date or diary entry.|  | | <a name=\"800\">800</a>|Can not upsert an instrument event of this type.|  | | <a name=\"801\">801</a>|The instrument event does not exist.|  | | <a name=\"802\">802</a>|The Instrument event is missing salient information.|  | | <a name=\"803\">803</a>|The Instrument event could not be processed.|  | | <a name=\"804\">804</a>|Some data requested does not follow the order graph assumptions.|  | | <a name=\"805\">805</a>|The instrument event type does not exist.|  | | <a name=\"806\">806</a>|The transaction template specification does not exist.|  | | <a name=\"807\">807</a>|The default transaction template does not exist.|  | | <a name=\"808\">808</a>|The transaction template does not exist.|  | | <a name=\"811\">811</a>|A price could not be found for an order.|  | | <a name=\"812\">812</a>|A price could not be found for an allocation.|  | | <a name=\"813\">813</a>|Chart of Accounts not found.|  | | <a name=\"814\">814</a>|Account not found.|  | | <a name=\"815\">815</a>|Abor not found.|  | | <a name=\"816\">816</a>|Abor Configuration not found.|  | | <a name=\"817\">817</a>|Reconciliation mapping not found|  | | <a name=\"818\">818</a>|Attribute type could not be deleted because it doesn't exist.|  | | <a name=\"819\">819</a>|Reconciliation not found.|  | | <a name=\"820\">820</a>|Custodian Account not found.|  | | <a name=\"821\">821</a>|Allocation Failure|  | | <a name=\"822\">822</a>|Reconciliation run not found|  | | <a name=\"823\">823</a>|Reconciliation break not found|  | | <a name=\"824\">824</a>|Entity link type could not be deleted because it doesn't exist.|  | | <a name=\"828\">828</a>|Address key definition not found.|  | | <a name=\"829\">829</a>|Compliance template not found.|  | | <a name=\"830\">830</a>|Action not supported|  | | <a name=\"831\">831</a>|Reference list not found.|  | | <a name=\"832\">832</a>|Posting Module not found.|  | | <a name=\"833\">833</a>|The type of parameter provided did not match that required by the compliance rule.|  | | <a name=\"834\">834</a>|The parameters provided by a rule did not match those required by its template.|  | | <a name=\"835\">835</a>|The entity has a property in a domain that is not supprted for that entity type.|  | | <a name=\"836\">836</a>|Structured result data not found.|  | | <a name=\"837\">837</a>|Diary entry not found.|  | | <a name=\"838\">838</a>|Diary entry could not be created.|  | | <a name=\"839\">839</a>|Diary entry already exists.|  | | <a name=\"861\">861</a>|Compliance run summary not found.|  | | <a name=\"869\">869</a>|Conflicting instrument properties in batch.|  | | <a name=\"870\">870</a>|Compliance run summary already exists.|  | | <a name=\"871\">871</a>|The specified impersonated user does not exist|  | | <a name=\"874\">874</a>|Provided Property Domain is not supported for entity filter.|  | | <a name=\"875\">875</a>|Cannot Delete System Reference List.|  | | <a name=\"876\">876</a>|Cleardown Module not found.|  | | <a name=\"879\">879</a>|Portfolios do not have the same base currency|  | | <a name=\"880\">880</a>|There was a problem with the definition of the compliance expression.|  | | <a name=\"881\">881</a>|Block overplaced.|  | | <a name=\"882\">882</a>|Order not approved.|  | | <a name=\"883\">883</a>|Cannot update the shared fields of a block with associated orders.|  | | <a name=\"886\">886</a>|Cannot lock the period.|  | | <a name=\"887\">887</a>|Cannot apply clear down module.|  | | <a name=\"888\">888</a>|Cannot upsert Instrument Event Instruction.|  | | <a name=\"889\">889</a>|Cannot read Instrument Event Instruction.|  | | <a name=\"895\">895</a>|The Capital Ratio Calculation Is Wrong.|  | | <a name=\"910\">910</a>|Cannot update a block referenced by a placement.|  | | <a name=\"911\">911</a>|A Fund that references this Abor already exists.|  | | <a name=\"912\">912</a>|Cannot add decision to Staged Modification.|  | | <a name=\"913\">913</a>|The Staged Modification could not be applied.|  | | <a name=\"914\">914</a>|Action cannot be executed.|  | | <a name=\"915\">915</a>|Cannot upsert multiple versions of the same property in one request.|  | | <a name=\"916\">916</a>|Placement and direct descendents have more executed quantity than total placement quantity.|  | | <a name=\"917\">917</a>|Cannot update a placement with this EntryType.|  | | <a name=\"918\">918</a>|Cannot update a placement in this State.|  | | <a name=\"919\">919</a>|Placement could not be cancelled.|  | | <a name=\"920\">920</a>|Share Class not configured in Fund|  | | <a name=\"921\">921</a>|Share Class Sub Holding Key not configured in Portfolio|  | | <a name=\"922\">922</a>|Could not update an order.|  | | <a name=\"923\">923</a>|Multiple sets of Share Class Sub Holding Keys configured across the Portfolios of a Fund.|  | | <a name=\"924\">924</a>|One or more matrix cells could not be added to the matrix.|  | | <a name=\"925\">925</a>|There was a problem with the provided matrix definition.|  | | <a name=\"926\">926</a>|Matrix definition does not exist.|  | | <a name=\"927\">927</a>|Matrix definition could not be deleted because it doesn't exist.|  | 
 *
 * The version of the OpenAPI document: 1.1.435
 * Contact: info@finbourne.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Lusid.Sdk.Client.OpenAPIDateConverter;

namespace Lusid.Sdk.Model
{
    /// <summary>
    /// CapitalDistributionEventAllOf
    /// </summary>
    [DataContract(Name = "CapitalDistributionEvent_allOf")]
    public partial class CapitalDistributionEventAllOf : IEquatable<CapitalDistributionEventAllOf>
    {
        /// <summary>
        /// The Type of Event. The available values are: TransitionEvent, InformationalEvent, OpenEvent, CloseEvent, StockSplitEvent, BondDefaultEvent, CashDividendEvent, AmortisationEvent, CashFlowEvent, ExerciseEvent, ResetEvent, TriggerEvent, RawVendorEvent, InformationalErrorEvent, BondCouponEvent, DividendReinvestmentEvent, AccumulationEvent, BondPrincipalEvent, DividendOptionEvent, MaturityEvent, FxForwardSettlementEvent, ExpiryEvent, ScripDividendEvent, StockDividendEvent, ReverseStockSplitEvent, CapitalDistributionEvent, SpinOffEvent, MergerEvent, FutureExpiryEvent, SwapCashFlowEvent, SwapPrincipalEvent, CreditPremiumCashFlowEvent, CdsCreditEvent, CdxCreditEvent, MbsCouponEvent, MbsPrincipalEvent, BonusIssueEvent, MbsPrincipalWriteOffEvent, MbsInterestDeferralEvent, MbsInterestShortfallEvent, TenderEvent, CallOnIntermediateSecuritiesEvent, IntermediateSecuritiesDistributionEvent, OptionExercisePhysicalEvent, ProtectionPayoutCashFlowEvent
        /// </summary>
        /// <value>The Type of Event. The available values are: TransitionEvent, InformationalEvent, OpenEvent, CloseEvent, StockSplitEvent, BondDefaultEvent, CashDividendEvent, AmortisationEvent, CashFlowEvent, ExerciseEvent, ResetEvent, TriggerEvent, RawVendorEvent, InformationalErrorEvent, BondCouponEvent, DividendReinvestmentEvent, AccumulationEvent, BondPrincipalEvent, DividendOptionEvent, MaturityEvent, FxForwardSettlementEvent, ExpiryEvent, ScripDividendEvent, StockDividendEvent, ReverseStockSplitEvent, CapitalDistributionEvent, SpinOffEvent, MergerEvent, FutureExpiryEvent, SwapCashFlowEvent, SwapPrincipalEvent, CreditPremiumCashFlowEvent, CdsCreditEvent, CdxCreditEvent, MbsCouponEvent, MbsPrincipalEvent, BonusIssueEvent, MbsPrincipalWriteOffEvent, MbsInterestDeferralEvent, MbsInterestShortfallEvent, TenderEvent, CallOnIntermediateSecuritiesEvent, IntermediateSecuritiesDistributionEvent, OptionExercisePhysicalEvent, ProtectionPayoutCashFlowEvent</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum InstrumentEventTypeEnum
        {
            /// <summary>
            /// Enum TransitionEvent for value: TransitionEvent
            /// </summary>
            [EnumMember(Value = "TransitionEvent")]
            TransitionEvent = 1,

            /// <summary>
            /// Enum InformationalEvent for value: InformationalEvent
            /// </summary>
            [EnumMember(Value = "InformationalEvent")]
            InformationalEvent = 2,

            /// <summary>
            /// Enum OpenEvent for value: OpenEvent
            /// </summary>
            [EnumMember(Value = "OpenEvent")]
            OpenEvent = 3,

            /// <summary>
            /// Enum CloseEvent for value: CloseEvent
            /// </summary>
            [EnumMember(Value = "CloseEvent")]
            CloseEvent = 4,

            /// <summary>
            /// Enum StockSplitEvent for value: StockSplitEvent
            /// </summary>
            [EnumMember(Value = "StockSplitEvent")]
            StockSplitEvent = 5,

            /// <summary>
            /// Enum BondDefaultEvent for value: BondDefaultEvent
            /// </summary>
            [EnumMember(Value = "BondDefaultEvent")]
            BondDefaultEvent = 6,

            /// <summary>
            /// Enum CashDividendEvent for value: CashDividendEvent
            /// </summary>
            [EnumMember(Value = "CashDividendEvent")]
            CashDividendEvent = 7,

            /// <summary>
            /// Enum AmortisationEvent for value: AmortisationEvent
            /// </summary>
            [EnumMember(Value = "AmortisationEvent")]
            AmortisationEvent = 8,

            /// <summary>
            /// Enum CashFlowEvent for value: CashFlowEvent
            /// </summary>
            [EnumMember(Value = "CashFlowEvent")]
            CashFlowEvent = 9,

            /// <summary>
            /// Enum ExerciseEvent for value: ExerciseEvent
            /// </summary>
            [EnumMember(Value = "ExerciseEvent")]
            ExerciseEvent = 10,

            /// <summary>
            /// Enum ResetEvent for value: ResetEvent
            /// </summary>
            [EnumMember(Value = "ResetEvent")]
            ResetEvent = 11,

            /// <summary>
            /// Enum TriggerEvent for value: TriggerEvent
            /// </summary>
            [EnumMember(Value = "TriggerEvent")]
            TriggerEvent = 12,

            /// <summary>
            /// Enum RawVendorEvent for value: RawVendorEvent
            /// </summary>
            [EnumMember(Value = "RawVendorEvent")]
            RawVendorEvent = 13,

            /// <summary>
            /// Enum InformationalErrorEvent for value: InformationalErrorEvent
            /// </summary>
            [EnumMember(Value = "InformationalErrorEvent")]
            InformationalErrorEvent = 14,

            /// <summary>
            /// Enum BondCouponEvent for value: BondCouponEvent
            /// </summary>
            [EnumMember(Value = "BondCouponEvent")]
            BondCouponEvent = 15,

            /// <summary>
            /// Enum DividendReinvestmentEvent for value: DividendReinvestmentEvent
            /// </summary>
            [EnumMember(Value = "DividendReinvestmentEvent")]
            DividendReinvestmentEvent = 16,

            /// <summary>
            /// Enum AccumulationEvent for value: AccumulationEvent
            /// </summary>
            [EnumMember(Value = "AccumulationEvent")]
            AccumulationEvent = 17,

            /// <summary>
            /// Enum BondPrincipalEvent for value: BondPrincipalEvent
            /// </summary>
            [EnumMember(Value = "BondPrincipalEvent")]
            BondPrincipalEvent = 18,

            /// <summary>
            /// Enum DividendOptionEvent for value: DividendOptionEvent
            /// </summary>
            [EnumMember(Value = "DividendOptionEvent")]
            DividendOptionEvent = 19,

            /// <summary>
            /// Enum MaturityEvent for value: MaturityEvent
            /// </summary>
            [EnumMember(Value = "MaturityEvent")]
            MaturityEvent = 20,

            /// <summary>
            /// Enum FxForwardSettlementEvent for value: FxForwardSettlementEvent
            /// </summary>
            [EnumMember(Value = "FxForwardSettlementEvent")]
            FxForwardSettlementEvent = 21,

            /// <summary>
            /// Enum ExpiryEvent for value: ExpiryEvent
            /// </summary>
            [EnumMember(Value = "ExpiryEvent")]
            ExpiryEvent = 22,

            /// <summary>
            /// Enum ScripDividendEvent for value: ScripDividendEvent
            /// </summary>
            [EnumMember(Value = "ScripDividendEvent")]
            ScripDividendEvent = 23,

            /// <summary>
            /// Enum StockDividendEvent for value: StockDividendEvent
            /// </summary>
            [EnumMember(Value = "StockDividendEvent")]
            StockDividendEvent = 24,

            /// <summary>
            /// Enum ReverseStockSplitEvent for value: ReverseStockSplitEvent
            /// </summary>
            [EnumMember(Value = "ReverseStockSplitEvent")]
            ReverseStockSplitEvent = 25,

            /// <summary>
            /// Enum CapitalDistributionEvent for value: CapitalDistributionEvent
            /// </summary>
            [EnumMember(Value = "CapitalDistributionEvent")]
            CapitalDistributionEvent = 26,

            /// <summary>
            /// Enum SpinOffEvent for value: SpinOffEvent
            /// </summary>
            [EnumMember(Value = "SpinOffEvent")]
            SpinOffEvent = 27,

            /// <summary>
            /// Enum MergerEvent for value: MergerEvent
            /// </summary>
            [EnumMember(Value = "MergerEvent")]
            MergerEvent = 28,

            /// <summary>
            /// Enum FutureExpiryEvent for value: FutureExpiryEvent
            /// </summary>
            [EnumMember(Value = "FutureExpiryEvent")]
            FutureExpiryEvent = 29,

            /// <summary>
            /// Enum SwapCashFlowEvent for value: SwapCashFlowEvent
            /// </summary>
            [EnumMember(Value = "SwapCashFlowEvent")]
            SwapCashFlowEvent = 30,

            /// <summary>
            /// Enum SwapPrincipalEvent for value: SwapPrincipalEvent
            /// </summary>
            [EnumMember(Value = "SwapPrincipalEvent")]
            SwapPrincipalEvent = 31,

            /// <summary>
            /// Enum CreditPremiumCashFlowEvent for value: CreditPremiumCashFlowEvent
            /// </summary>
            [EnumMember(Value = "CreditPremiumCashFlowEvent")]
            CreditPremiumCashFlowEvent = 32,

            /// <summary>
            /// Enum CdsCreditEvent for value: CdsCreditEvent
            /// </summary>
            [EnumMember(Value = "CdsCreditEvent")]
            CdsCreditEvent = 33,

            /// <summary>
            /// Enum CdxCreditEvent for value: CdxCreditEvent
            /// </summary>
            [EnumMember(Value = "CdxCreditEvent")]
            CdxCreditEvent = 34,

            /// <summary>
            /// Enum MbsCouponEvent for value: MbsCouponEvent
            /// </summary>
            [EnumMember(Value = "MbsCouponEvent")]
            MbsCouponEvent = 35,

            /// <summary>
            /// Enum MbsPrincipalEvent for value: MbsPrincipalEvent
            /// </summary>
            [EnumMember(Value = "MbsPrincipalEvent")]
            MbsPrincipalEvent = 36,

            /// <summary>
            /// Enum BonusIssueEvent for value: BonusIssueEvent
            /// </summary>
            [EnumMember(Value = "BonusIssueEvent")]
            BonusIssueEvent = 37,

            /// <summary>
            /// Enum MbsPrincipalWriteOffEvent for value: MbsPrincipalWriteOffEvent
            /// </summary>
            [EnumMember(Value = "MbsPrincipalWriteOffEvent")]
            MbsPrincipalWriteOffEvent = 38,

            /// <summary>
            /// Enum MbsInterestDeferralEvent for value: MbsInterestDeferralEvent
            /// </summary>
            [EnumMember(Value = "MbsInterestDeferralEvent")]
            MbsInterestDeferralEvent = 39,

            /// <summary>
            /// Enum MbsInterestShortfallEvent for value: MbsInterestShortfallEvent
            /// </summary>
            [EnumMember(Value = "MbsInterestShortfallEvent")]
            MbsInterestShortfallEvent = 40,

            /// <summary>
            /// Enum TenderEvent for value: TenderEvent
            /// </summary>
            [EnumMember(Value = "TenderEvent")]
            TenderEvent = 41,

            /// <summary>
            /// Enum CallOnIntermediateSecuritiesEvent for value: CallOnIntermediateSecuritiesEvent
            /// </summary>
            [EnumMember(Value = "CallOnIntermediateSecuritiesEvent")]
            CallOnIntermediateSecuritiesEvent = 42,

            /// <summary>
            /// Enum IntermediateSecuritiesDistributionEvent for value: IntermediateSecuritiesDistributionEvent
            /// </summary>
            [EnumMember(Value = "IntermediateSecuritiesDistributionEvent")]
            IntermediateSecuritiesDistributionEvent = 43,

            /// <summary>
            /// Enum OptionExercisePhysicalEvent for value: OptionExercisePhysicalEvent
            /// </summary>
            [EnumMember(Value = "OptionExercisePhysicalEvent")]
            OptionExercisePhysicalEvent = 44,

            /// <summary>
            /// Enum ProtectionPayoutCashFlowEvent for value: ProtectionPayoutCashFlowEvent
            /// </summary>
            [EnumMember(Value = "ProtectionPayoutCashFlowEvent")]
            ProtectionPayoutCashFlowEvent = 45

        }


        /// <summary>
        /// The Type of Event. The available values are: TransitionEvent, InformationalEvent, OpenEvent, CloseEvent, StockSplitEvent, BondDefaultEvent, CashDividendEvent, AmortisationEvent, CashFlowEvent, ExerciseEvent, ResetEvent, TriggerEvent, RawVendorEvent, InformationalErrorEvent, BondCouponEvent, DividendReinvestmentEvent, AccumulationEvent, BondPrincipalEvent, DividendOptionEvent, MaturityEvent, FxForwardSettlementEvent, ExpiryEvent, ScripDividendEvent, StockDividendEvent, ReverseStockSplitEvent, CapitalDistributionEvent, SpinOffEvent, MergerEvent, FutureExpiryEvent, SwapCashFlowEvent, SwapPrincipalEvent, CreditPremiumCashFlowEvent, CdsCreditEvent, CdxCreditEvent, MbsCouponEvent, MbsPrincipalEvent, BonusIssueEvent, MbsPrincipalWriteOffEvent, MbsInterestDeferralEvent, MbsInterestShortfallEvent, TenderEvent, CallOnIntermediateSecuritiesEvent, IntermediateSecuritiesDistributionEvent, OptionExercisePhysicalEvent, ProtectionPayoutCashFlowEvent
        /// </summary>
        /// <value>The Type of Event. The available values are: TransitionEvent, InformationalEvent, OpenEvent, CloseEvent, StockSplitEvent, BondDefaultEvent, CashDividendEvent, AmortisationEvent, CashFlowEvent, ExerciseEvent, ResetEvent, TriggerEvent, RawVendorEvent, InformationalErrorEvent, BondCouponEvent, DividendReinvestmentEvent, AccumulationEvent, BondPrincipalEvent, DividendOptionEvent, MaturityEvent, FxForwardSettlementEvent, ExpiryEvent, ScripDividendEvent, StockDividendEvent, ReverseStockSplitEvent, CapitalDistributionEvent, SpinOffEvent, MergerEvent, FutureExpiryEvent, SwapCashFlowEvent, SwapPrincipalEvent, CreditPremiumCashFlowEvent, CdsCreditEvent, CdxCreditEvent, MbsCouponEvent, MbsPrincipalEvent, BonusIssueEvent, MbsPrincipalWriteOffEvent, MbsInterestDeferralEvent, MbsInterestShortfallEvent, TenderEvent, CallOnIntermediateSecuritiesEvent, IntermediateSecuritiesDistributionEvent, OptionExercisePhysicalEvent, ProtectionPayoutCashFlowEvent</value>
        [DataMember(Name = "instrumentEventType", IsRequired = true, EmitDefaultValue = false)]
        public InstrumentEventTypeEnum InstrumentEventType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CapitalDistributionEventAllOf" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CapitalDistributionEventAllOf() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CapitalDistributionEventAllOf" /> class.
        /// </summary>
        /// <param name="announcementDate">Date on which the dividend was announced / declared..</param>
        /// <param name="cashElections">Possible elections for this event, each keyed with a unique identifier. (required).</param>
        /// <param name="exDate">The first business day on which the dividend is not owed to the buying party. (required).</param>
        /// <param name="paymentDate">The date the company begins distributing the dividend. (required).</param>
        /// <param name="recordDate">Date you have to be the holder of record in order to participate in the tender..</param>
        /// <param name="instrumentEventType">The Type of Event. The available values are: TransitionEvent, InformationalEvent, OpenEvent, CloseEvent, StockSplitEvent, BondDefaultEvent, CashDividendEvent, AmortisationEvent, CashFlowEvent, ExerciseEvent, ResetEvent, TriggerEvent, RawVendorEvent, InformationalErrorEvent, BondCouponEvent, DividendReinvestmentEvent, AccumulationEvent, BondPrincipalEvent, DividendOptionEvent, MaturityEvent, FxForwardSettlementEvent, ExpiryEvent, ScripDividendEvent, StockDividendEvent, ReverseStockSplitEvent, CapitalDistributionEvent, SpinOffEvent, MergerEvent, FutureExpiryEvent, SwapCashFlowEvent, SwapPrincipalEvent, CreditPremiumCashFlowEvent, CdsCreditEvent, CdxCreditEvent, MbsCouponEvent, MbsPrincipalEvent, BonusIssueEvent, MbsPrincipalWriteOffEvent, MbsInterestDeferralEvent, MbsInterestShortfallEvent, TenderEvent, CallOnIntermediateSecuritiesEvent, IntermediateSecuritiesDistributionEvent, OptionExercisePhysicalEvent, ProtectionPayoutCashFlowEvent (required).</param>
        public CapitalDistributionEventAllOf(DateTimeOffset? announcementDate = default(DateTimeOffset?), List<CashElection> cashElections = default(List<CashElection>), DateTimeOffset exDate = default(DateTimeOffset), DateTimeOffset paymentDate = default(DateTimeOffset), DateTimeOffset? recordDate = default(DateTimeOffset?), InstrumentEventTypeEnum instrumentEventType = default(InstrumentEventTypeEnum))
        {
            // to ensure "cashElections" is required (not null)
            this.CashElections = cashElections ?? throw new ArgumentNullException("cashElections is a required property for CapitalDistributionEventAllOf and cannot be null");
            this.ExDate = exDate;
            this.PaymentDate = paymentDate;
            this.InstrumentEventType = instrumentEventType;
            this.AnnouncementDate = announcementDate;
            this.RecordDate = recordDate;
        }

        /// <summary>
        /// Date on which the dividend was announced / declared.
        /// </summary>
        /// <value>Date on which the dividend was announced / declared.</value>
        [DataMember(Name = "announcementDate", EmitDefaultValue = true)]
        public DateTimeOffset? AnnouncementDate { get; set; }

        /// <summary>
        /// Possible elections for this event, each keyed with a unique identifier.
        /// </summary>
        /// <value>Possible elections for this event, each keyed with a unique identifier.</value>
        [DataMember(Name = "cashElections", IsRequired = true, EmitDefaultValue = false)]
        public List<CashElection> CashElections { get; set; }

        /// <summary>
        /// The first business day on which the dividend is not owed to the buying party.
        /// </summary>
        /// <value>The first business day on which the dividend is not owed to the buying party.</value>
        [DataMember(Name = "exDate", IsRequired = true, EmitDefaultValue = false)]
        public DateTimeOffset ExDate { get; set; }

        /// <summary>
        /// The date the company begins distributing the dividend.
        /// </summary>
        /// <value>The date the company begins distributing the dividend.</value>
        [DataMember(Name = "paymentDate", IsRequired = true, EmitDefaultValue = false)]
        public DateTimeOffset PaymentDate { get; set; }

        /// <summary>
        /// Date you have to be the holder of record in order to participate in the tender.
        /// </summary>
        /// <value>Date you have to be the holder of record in order to participate in the tender.</value>
        [DataMember(Name = "recordDate", EmitDefaultValue = true)]
        public DateTimeOffset? RecordDate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CapitalDistributionEventAllOf {\n");
            sb.Append("  AnnouncementDate: ").Append(AnnouncementDate).Append("\n");
            sb.Append("  CashElections: ").Append(CashElections).Append("\n");
            sb.Append("  ExDate: ").Append(ExDate).Append("\n");
            sb.Append("  PaymentDate: ").Append(PaymentDate).Append("\n");
            sb.Append("  RecordDate: ").Append(RecordDate).Append("\n");
            sb.Append("  InstrumentEventType: ").Append(InstrumentEventType).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as CapitalDistributionEventAllOf);
        }

        /// <summary>
        /// Returns true if CapitalDistributionEventAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of CapitalDistributionEventAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CapitalDistributionEventAllOf input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AnnouncementDate == input.AnnouncementDate ||
                    (this.AnnouncementDate != null &&
                    this.AnnouncementDate.Equals(input.AnnouncementDate))
                ) && 
                (
                    this.CashElections == input.CashElections ||
                    this.CashElections != null &&
                    input.CashElections != null &&
                    this.CashElections.SequenceEqual(input.CashElections)
                ) && 
                (
                    this.ExDate == input.ExDate ||
                    (this.ExDate != null &&
                    this.ExDate.Equals(input.ExDate))
                ) && 
                (
                    this.PaymentDate == input.PaymentDate ||
                    (this.PaymentDate != null &&
                    this.PaymentDate.Equals(input.PaymentDate))
                ) && 
                (
                    this.RecordDate == input.RecordDate ||
                    (this.RecordDate != null &&
                    this.RecordDate.Equals(input.RecordDate))
                ) && 
                (
                    this.InstrumentEventType == input.InstrumentEventType ||
                    this.InstrumentEventType.Equals(input.InstrumentEventType)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.AnnouncementDate != null)
                    hashCode = hashCode * 59 + this.AnnouncementDate.GetHashCode();
                if (this.CashElections != null)
                    hashCode = hashCode * 59 + this.CashElections.GetHashCode();
                if (this.ExDate != null)
                    hashCode = hashCode * 59 + this.ExDate.GetHashCode();
                if (this.PaymentDate != null)
                    hashCode = hashCode * 59 + this.PaymentDate.GetHashCode();
                if (this.RecordDate != null)
                    hashCode = hashCode * 59 + this.RecordDate.GetHashCode();
                hashCode = hashCode * 59 + this.InstrumentEventType.GetHashCode();
                return hashCode;
            }
        }

    }
}
