/*
 * LUSID API
 *
 * # Introduction  This page documents the [LUSID APIs](../../../api/swagger), which allows authorised clients to query and update their data within the LUSID platform.  SDKs to interact with the LUSID APIs are available in the following languages and frameworks:  * [C#](https://github.com/finbourne/lusid-sdk-csharp) * [Java](https://github.com/finbourne/lusid-sdk-java) * [JavaScript](https://github.com/finbourne/lusid-sdk-js) * [Python](https://github.com/finbourne/lusid-sdk-python) * [Angular](https://github.com/finbourne/lusid-sdk-angular)  The LUSID platform is made up of a number of sub-applications. You can find the API / swagger documentation by following the links in the table below.   | Application   | Description                                                                       | API / Swagger Documentation                          | |- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | LUSID         | Open, API-first, developer-friendly investment data platform.                     | [Swagger](../../../api/swagger/index.html)           | | Web app       | User-facing front end for LUSID.                                                  | [Swagger](../../../app/swagger/index.html)           | | Scheduler     | Automated job scheduler.                                                          | [Swagger](../../../scheduler2/swagger/index.html)    | | Insights      | Monitoring and troubleshooting service.                                           | [Swagger](../../../insights/swagger/index.html)      | | Identity      | Identity management for LUSID (in conjunction with Access)                        | [Swagger](../../../identity/swagger/index.html)      | | Access        | Access control for LUSID (in conjunction with Identity)                           | [Swagger](../../../access/swagger/index.html)        | | Drive         | Secure file repository and manager for collaboration.                             | [Swagger](../../../drive/swagger/index.html)         | | Luminesce     | Data virtualisation service (query data from multiple providers, including LUSID) | [Swagger](../../../honeycomb/swagger/index.html)     | | Notification  | Notification service.                                                             | [Swagger](../../../notification/swagger/index.html)  | | Configuration | File store for secrets and other sensitive information.                           | [Swagger](../../../configuration/swagger/index.html) | | Workflow      | Workflow service.                                                                 | [Swagger](../../../workflow/swagger/index.html)      |   # Error Codes  | Code|Name|Description | | - --|- --|- -- | | <a name=\"-10\">-10</a>|Server Configuration Error|  | | <a name=\"-1\">-1</a>|Unknown error|An unexpected error was encountered on our side. | | <a name=\"102\">102</a>|Version Not Found|  | | <a name=\"103\">103</a>|Api Rate Limit Violation|  | | <a name=\"104\">104</a>|Instrument Not Found|  | | <a name=\"105\">105</a>|Property Not Found|  | | <a name=\"106\">106</a>|Portfolio Recursion Depth|  | | <a name=\"108\">108</a>|Group Not Found|  | | <a name=\"109\">109</a>|Portfolio Not Found|  | | <a name=\"110\">110</a>|Property Schema Not Found|  | | <a name=\"111\">111</a>|Portfolio Ancestry Not Found|  | | <a name=\"112\">112</a>|Portfolio With Id Already Exists|  | | <a name=\"113\">113</a>|Orphaned Portfolio|  | | <a name=\"119\">119</a>|Missing Base Claims|  | | <a name=\"121\">121</a>|Property Not Defined|  | | <a name=\"122\">122</a>|Cannot Delete System Property|  | | <a name=\"123\">123</a>|Cannot Modify Immutable Property Field|  | | <a name=\"124\">124</a>|Property Already Exists|  | | <a name=\"125\">125</a>|Invalid Property Life Time|  | | <a name=\"126\">126</a>|Property Constraint Style Excludes Properties|  | | <a name=\"127\">127</a>|Cannot Modify Default Data Type|  | | <a name=\"128\">128</a>|Group Already Exists|  | | <a name=\"129\">129</a>|No Such Data Type|  | | <a name=\"130\">130</a>|Undefined Value For Data Type|  | | <a name=\"131\">131</a>|Unsupported Value Type Defined On Data Type|  | | <a name=\"132\">132</a>|Validation Error|  | | <a name=\"133\">133</a>|Loop Detected In Group Hierarchy|  | | <a name=\"134\">134</a>|Undefined Acceptable Values|  | | <a name=\"135\">135</a>|Sub Group Already Exists|  | | <a name=\"138\">138</a>|Price Source Not Found|  | | <a name=\"139\">139</a>|Analytic Store Not Found|  | | <a name=\"141\">141</a>|Analytic Store Already Exists|  | | <a name=\"143\">143</a>|Client Instrument Already Exists|  | | <a name=\"144\">144</a>|Duplicate In Parameter Set|  | | <a name=\"147\">147</a>|Results Not Found|  | | <a name=\"148\">148</a>|Order Field Not In Result Set|  | | <a name=\"149\">149</a>|Operation Failed|  | | <a name=\"150\">150</a>|Elastic Search Error|  | | <a name=\"151\">151</a>|Invalid Parameter Value|  | | <a name=\"153\">153</a>|Command Processing Failure|  | | <a name=\"154\">154</a>|Entity State Construction Failure|  | | <a name=\"155\">155</a>|Entity Timeline Does Not Exist|  | | <a name=\"156\">156</a>|Concurrency Conflict Failure|  | | <a name=\"157\">157</a>|Invalid Request|  | | <a name=\"158\">158</a>|Event Publish Unknown|  | | <a name=\"159\">159</a>|Event Query Failure|  | | <a name=\"160\">160</a>|Blob Did Not Exist|  | | <a name=\"162\">162</a>|Sub System Request Failure|  | | <a name=\"163\">163</a>|Sub System Configuration Failure|  | | <a name=\"165\">165</a>|Failed To Delete|  | | <a name=\"166\">166</a>|Upsert Client Instrument Failure|  | | <a name=\"167\">167</a>|Illegal As At Interval|  | | <a name=\"168\">168</a>|Illegal Bitemporal Query|  | | <a name=\"169\">169</a>|Invalid Alternate Id|  | | <a name=\"170\">170</a>|Cannot Add Non-Writable Properties To Entity|  | | <a name=\"171\">171</a>|Entity Already Exists In Group|  | | <a name=\"172\">172</a>|Entity With Id Does Not Exist|  | | <a name=\"173\">173</a>|Entity With Id Already Exists|  | | <a name=\"174\">174</a>|Derived Portfolio Details Do Not Exist|  | | <a name=\"175\">175</a>|Entity Not In Group|  | | <a name=\"176\">176</a>|Portfolio With Name Already Exists|  | | <a name=\"177\">177</a>|Invalid Transactions|  | | <a name=\"178\">178</a>|Reference Portfolio Not Found|  | | <a name=\"179\">179</a>|Duplicate Id|  | | <a name=\"180\">180</a>|Command Retrieval Failure|  | | <a name=\"181\">181</a>|Data Filter Application Failure|  | | <a name=\"182\">182</a>|Search Failed|  | | <a name=\"183\">183</a>|Movements Engine Configuration Key Failure|  | | <a name=\"184\">184</a>|Fx Rate Source Not Found|  | | <a name=\"185\">185</a>|Accrual Source Not Found|  | | <a name=\"186\">186</a>|Access Denied|  | | <a name=\"187\">187</a>|Invalid Identity Token|  | | <a name=\"188\">188</a>|Invalid Request Headers|  | | <a name=\"189\">189</a>|Price Not Found|  | | <a name=\"190\">190</a>|Invalid Sub Holding Keys Provided|  | | <a name=\"191\">191</a>|Duplicate Sub Holding Keys Provided|  | | <a name=\"192\">192</a>|Cut Definition Not Found|  | | <a name=\"193\">193</a>|Cut Definition Invalid|  | | <a name=\"194\">194</a>|Time Variant Property Deletion Date Unspecified|  | | <a name=\"195\">195</a>|Perpetual Property Deletion Date Specified|  | | <a name=\"196\">196</a>|Time Variant Property Upsert Date Unspecified|  | | <a name=\"197\">197</a>|Perpetual Property Upsert Date Specified|  | | <a name=\"200\">200</a>|Invalid Unit For Data Type|  | | <a name=\"201\">201</a>|Invalid Type For Data Type|  | | <a name=\"202\">202</a>|Invalid Value For Data Type|  | | <a name=\"203\">203</a>|Unit Not Defined For Data Type|  | | <a name=\"204\">204</a>|Units Not Supported On Data Type|  | | <a name=\"205\">205</a>|Cannot Specify Units On Data Type|  | | <a name=\"206\">206</a>|Unit Schema Inconsistent With Data Type|  | | <a name=\"207\">207</a>|Unit Definition Not Specified|  | | <a name=\"208\">208</a>|Duplicate Unit Definitions Specified|  | | <a name=\"209\">209</a>|Invalid Units Definition|  | | <a name=\"210\">210</a>|Invalid Instrument Identifier Unit|  | | <a name=\"211\">211</a>|Holdings Adjustment Does Not Exist|  | | <a name=\"212\">212</a>|Could Not Build Excel Url|  | | <a name=\"213\">213</a>|Could Not Get Excel Version|  | | <a name=\"214\">214</a>|Instrument By Code Not Found|  | | <a name=\"215\">215</a>|Entity Schema Does Not Exist|  | | <a name=\"216\">216</a>|Feature Not Supported On Portfolio Type|  | | <a name=\"217\">217</a>|Quote Not Found|  | | <a name=\"218\">218</a>|Invalid Quote Identifier|  | | <a name=\"219\">219</a>|Invalid Metric For Data Type|  | | <a name=\"220\">220</a>|Invalid Instrument Definition|  | | <a name=\"221\">221</a>|Instrument Upsert Failure|  | | <a name=\"222\">222</a>|Reference Portfolio Request Not Supported|  | | <a name=\"223\">223</a>|Transaction Portfolio Request Not Supported|  | | <a name=\"224\">224</a>|Invalid Property Value Assignment|  | | <a name=\"230\">230</a>|Transaction Type Not Found|  | | <a name=\"231\">231</a>|Transaction Type Duplication|  | | <a name=\"232\">232</a>|Portfolio Does Not Exist At Given Date|  | | <a name=\"233\">233</a>|Query Parser Failure|  | | <a name=\"234\">234</a>|Duplicate Constituent|  | | <a name=\"235\">235</a>|Unresolved Instrument Constituent|  | | <a name=\"236\">236</a>|Unresolved Instrument In Transition|  | | <a name=\"237\">237</a>|Missing Side Definitions|  | | <a name=\"240\">240</a>|Duplicate Calculations Failure|  | | <a name=\"299\">299</a>|Invalid Recipe|  | | <a name=\"300\">300</a>|Missing Recipe|  | | <a name=\"301\">301</a>|Dependencies|  | | <a name=\"304\">304</a>|Portfolio Preprocess Failure|  | | <a name=\"310\">310</a>|Valuation Engine Failure|  | | <a name=\"311\">311</a>|Task Factory Failure|  | | <a name=\"312\">312</a>|Task Evaluation Failure|  | | <a name=\"313\">313</a>|Task Generation Failure|  | | <a name=\"314\">314</a>|Engine Configuration Failure|  | | <a name=\"315\">315</a>|Model Specification Failure|  | | <a name=\"320\">320</a>|Market Data Key Failure|  | | <a name=\"321\">321</a>|Market Resolver Failure|  | | <a name=\"322\">322</a>|Market Data Failure|  | | <a name=\"330\">330</a>|Curve Failure|  | | <a name=\"331\">331</a>|Volatility Surface Failure|  | | <a name=\"332\">332</a>|Volatility Cube Failure|  | | <a name=\"350\">350</a>|Instrument Failure|  | | <a name=\"351\">351</a>|Cash Flows Failure|  | | <a name=\"352\">352</a>|Reference Data Failure|  | | <a name=\"360\">360</a>|Aggregation Failure|  | | <a name=\"361\">361</a>|Aggregation Measure Failure|  | | <a name=\"370\">370</a>|Result Retrieval Failure|  | | <a name=\"371\">371</a>|Result Processing Failure|  | | <a name=\"372\">372</a>|Vendor Result Processing Failure|  | | <a name=\"373\">373</a>|Vendor Result Mapping Failure|  | | <a name=\"374\">374</a>|Vendor Library Unauthorised|  | | <a name=\"375\">375</a>|Vendor Connectivity Error|  | | <a name=\"376\">376</a>|Vendor Interface Error|  | | <a name=\"377\">377</a>|Vendor Pricing Failure|  | | <a name=\"378\">378</a>|Vendor Translation Failure|  | | <a name=\"379\">379</a>|Vendor Key Mapping Failure|  | | <a name=\"380\">380</a>|Vendor Reflection Failure|  | | <a name=\"381\">381</a>|Vendor Process Failure|  | | <a name=\"382\">382</a>|Vendor System Failure|  | | <a name=\"390\">390</a>|Attempt To Upsert Duplicate Quotes|  | | <a name=\"391\">391</a>|Corporate Action Source Does Not Exist|  | | <a name=\"392\">392</a>|Corporate Action Source Already Exists|  | | <a name=\"393\">393</a>|Instrument Identifier Already In Use|  | | <a name=\"394\">394</a>|Properties Not Found|  | | <a name=\"395\">395</a>|Batch Operation Aborted|  | | <a name=\"400\">400</a>|Invalid Iso4217 Currency Code|  | | <a name=\"401\">401</a>|Cannot Assign Instrument Identifier To Currency|  | | <a name=\"402\">402</a>|Cannot Assign Currency Identifier To Non Currency|  | | <a name=\"403\">403</a>|Currency Instrument Cannot Be Deleted|  | | <a name=\"404\">404</a>|Currency Instrument Cannot Have Economic Definition|  | | <a name=\"405\">405</a>|Currency Instrument Cannot Have Lookthrough Portfolio|  | | <a name=\"406\">406</a>|Cannot Create Currency Instrument With Multiple Identifiers|  | | <a name=\"407\">407</a>|Specified Currency Is Undefined|  | | <a name=\"410\">410</a>|Index Does Not Exist|  | | <a name=\"411\">411</a>|Sort Field Does Not Exist|  | | <a name=\"413\">413</a>|Negative Pagination Parameters|  | | <a name=\"414\">414</a>|Invalid Search Syntax|  | | <a name=\"415\">415</a>|Filter Execution Timeout|  | | <a name=\"420\">420</a>|Side Definition Inconsistent|  | | <a name=\"450\">450</a>|Invalid Quote Access Metadata Rule|  | | <a name=\"451\">451</a>|Access Metadata Not Found|  | | <a name=\"452\">452</a>|Invalid Access Metadata Identifier|  | | <a name=\"460\">460</a>|Standard Resource Not Found|  | | <a name=\"461\">461</a>|Standard Resource Conflict|  | | <a name=\"462\">462</a>|Calendar Not Found|  | | <a name=\"463\">463</a>|Date In A Calendar Not Found|  | | <a name=\"464\">464</a>|Invalid Date Source Data|  | | <a name=\"465\">465</a>|Invalid Timezone|  | | <a name=\"601\">601</a>|Person Identifier Already In Use|  | | <a name=\"602\">602</a>|Person Not Found|  | | <a name=\"603\">603</a>|Cannot Set Identifier|  | | <a name=\"617\">617</a>|Invalid Recipe Specification In Request|  | | <a name=\"618\">618</a>|Inline Recipe Deserialisation Failure|  | | <a name=\"619\">619</a>|Identifier Types Not Set For Entity|  | | <a name=\"620\">620</a>|Cannot Delete All Client Defined Identifiers|  | | <a name=\"650\">650</a>|The Order requested was not found.|  | | <a name=\"654\">654</a>|The Allocation requested was not found.|  | | <a name=\"655\">655</a>|Cannot build the fx forward target with the given holdings.|  | | <a name=\"656\">656</a>|Group does not contain expected entities.|  | | <a name=\"665\">665</a>|Destination directory not found|  | | <a name=\"667\">667</a>|Relation definition already exists|  | | <a name=\"672\">672</a>|Could not retrieve file contents|  | | <a name=\"673\">673</a>|Missing entitlements for entities in Group|  | | <a name=\"674\">674</a>|Next Best Action not found|  | | <a name=\"676\">676</a>|Relation definition not defined|  | | <a name=\"677\">677</a>|Invalid entity identifier for relation|  | | <a name=\"681\">681</a>|Sorting by specified field not supported|One or more of the provided fields to order by were either invalid or not supported. | | <a name=\"682\">682</a>|Too many fields to sort by|The number of fields to sort the data by exceeds the number allowed by the endpoint | | <a name=\"684\">684</a>|Sequence Not Found|  | | <a name=\"685\">685</a>|Sequence Already Exists|  | | <a name=\"686\">686</a>|Non-cycling sequence has been exhausted|  | | <a name=\"687\">687</a>|Legal Entity Identifier Already In Use|  | | <a name=\"688\">688</a>|Legal Entity Not Found|  | | <a name=\"689\">689</a>|The supplied pagination token is invalid|  | | <a name=\"690\">690</a>|Property Type Is Not Supported|  | | <a name=\"691\">691</a>|Multiple Tax-lots For Currency Type Is Not Supported|  | | <a name=\"692\">692</a>|This endpoint does not support impersonation|  | | <a name=\"693\">693</a>|Entity type is not supported for Relationship|  | | <a name=\"694\">694</a>|Relationship Validation Failure|  | | <a name=\"695\">695</a>|Relationship Not Found|  | | <a name=\"697\">697</a>|Derived Property Formula No Longer Valid|  | | <a name=\"698\">698</a>|Story is not available|  | | <a name=\"703\">703</a>|Corporate Action Does Not Exist|  | | <a name=\"720\">720</a>|The provided sort and filter combination is not valid|  | | <a name=\"721\">721</a>|A2B generation failed|  | | <a name=\"722\">722</a>|Aggregated Return Calculation Failure|  | | <a name=\"723\">723</a>|Custom Entity Definition Identifier Already In Use|  | | <a name=\"724\">724</a>|Custom Entity Definition Not Found|  | | <a name=\"725\">725</a>|The Placement requested was not found.|  | | <a name=\"726\">726</a>|The Execution requested was not found.|  | | <a name=\"727\">727</a>|The Block requested was not found.|  | | <a name=\"728\">728</a>|The Participation requested was not found.|  | | <a name=\"729\">729</a>|The Package requested was not found.|  | | <a name=\"730\">730</a>|The OrderInstruction requested was not found.|  | | <a name=\"732\">732</a>|Custom Entity not found.|  | | <a name=\"733\">733</a>|Custom Entity Identifier already in use.|  | | <a name=\"735\">735</a>|Calculation Failed.|  | | <a name=\"736\">736</a>|An expected key on HttpResponse is missing.|  | | <a name=\"737\">737</a>|A required fee detail is missing.|  | | <a name=\"738\">738</a>|Zero rows were returned from Luminesce|  | | <a name=\"739\">739</a>|Provided Weekend Mask was invalid|  | | <a name=\"742\">742</a>|Custom Entity fields do not match the definition|  | | <a name=\"746\">746</a>|The provided sequence is not valid.|  | | <a name=\"751\">751</a>|The type of the Custom Entity is different than the type provided in the definition.|  | | <a name=\"752\">752</a>|Luminesce process returned an error.|  | | <a name=\"753\">753</a>|File name or content incompatible with operation.|  | | <a name=\"755\">755</a>|Schema of response from Drive is not as expected.|  | | <a name=\"757\">757</a>|Schema of response from Luminesce is not as expected.|  | | <a name=\"758\">758</a>|Luminesce timed out.|  | | <a name=\"763\">763</a>|Invalid Lusid Entity Identifier Unit|  | | <a name=\"768\">768</a>|Fee rule not found.|  | | <a name=\"769\">769</a>|Cannot update the base currency of a portfolio with transactions loaded|  | | <a name=\"771\">771</a>|Transaction configuration source not found|  | | <a name=\"774\">774</a>|Compliance rule not found.|  | | <a name=\"775\">775</a>|Fund accounting document cannot be processed.|  | | <a name=\"778\">778</a>|Unable to look up FX rate from trade ccy to portfolio ccy for some of the trades.|  | | <a name=\"782\">782</a>|The Property definition dataType is not matching the derivation formula dataType|  | | <a name=\"783\">783</a>|The Property definition domain is not supported for derived properties|  | | <a name=\"788\">788</a>|Compliance run not found failure.|  | | <a name=\"790\">790</a>|Custom Entity has missing or invalid identifiers|  | | <a name=\"791\">791</a>|Custom Entity definition already exists|  | | <a name=\"792\">792</a>|Compliance PropertyKey is missing.|  | | <a name=\"793\">793</a>|Compliance Criteria Value for matching is missing.|  | | <a name=\"795\">795</a>|Cannot delete identifier definition|  | | <a name=\"796\">796</a>|Tax rule set not found.|  | | <a name=\"797\">797</a>|A tax rule set with this id already exists.|  | | <a name=\"798\">798</a>|Multiple rule sets for the same property key are applicable.|  | | <a name=\"799\">799</a>|The request must contain a date or diary entry.|  | | <a name=\"800\">800</a>|Can not upsert an instrument event of this type.|  | | <a name=\"801\">801</a>|The instrument event does not exist.|  | | <a name=\"802\">802</a>|The Instrument event is missing salient information.|  | | <a name=\"803\">803</a>|The Instrument event could not be processed.|  | | <a name=\"804\">804</a>|Some data requested does not follow the order graph assumptions.|  | | <a name=\"805\">805</a>|The instrument event type does not exist.|  | | <a name=\"806\">806</a>|The transaction template specification does not exist.|  | | <a name=\"807\">807</a>|The default transaction template does not exist.|  | | <a name=\"808\">808</a>|The transaction template does not exist.|  | | <a name=\"811\">811</a>|A price could not be found for an order.|  | | <a name=\"812\">812</a>|A price could not be found for an allocation.|  | | <a name=\"813\">813</a>|Chart of Accounts not found.|  | | <a name=\"814\">814</a>|Account not found.|  | | <a name=\"815\">815</a>|Abor not found.|  | | <a name=\"816\">816</a>|Abor Configuration not found.|  | | <a name=\"817\">817</a>|Reconciliation mapping not found|  | | <a name=\"818\">818</a>|Attribute type could not be deleted because it doesn't exist.|  | | <a name=\"819\">819</a>|Reconciliation not found.|  | | <a name=\"820\">820</a>|Custodian Account not found.|  | | <a name=\"821\">821</a>|Allocation Failure|  | | <a name=\"822\">822</a>|Reconciliation run not found|  | | <a name=\"823\">823</a>|Reconciliation break not found|  | | <a name=\"824\">824</a>|Entity link type could not be deleted because it doesn't exist.|  | | <a name=\"828\">828</a>|Address key definition not found.|  | | <a name=\"829\">829</a>|Compliance template not found.|  | | <a name=\"830\">830</a>|Action not supported|  | | <a name=\"831\">831</a>|Reference list not found.|  | | <a name=\"832\">832</a>|Posting Module not found.|  | | <a name=\"833\">833</a>|The type of parameter provided did not match that required by the compliance rule.|  | | <a name=\"834\">834</a>|The parameters provided by a rule did not match those required by its template.|  | | <a name=\"835\">835</a>|The entity has a property in a domain that is not supprted for that entity type.|  | | <a name=\"836\">836</a>|Structured result data not found.|  | | <a name=\"837\">837</a>|Diary entry not found.|  | | <a name=\"838\">838</a>|Diary entry could not be created.|  | | <a name=\"839\">839</a>|Diary entry already exists.|  | | <a name=\"861\">861</a>|Compliance run summary not found.|  | | <a name=\"869\">869</a>|Conflicting instrument properties in batch.|  | | <a name=\"870\">870</a>|Compliance run summary already exists.|  | | <a name=\"871\">871</a>|The specified impersonated user does not exist|  | | <a name=\"874\">874</a>|Provided Property Domain is not supported for entity filter.|  | | <a name=\"875\">875</a>|Cannot Delete System Reference List.|  | | <a name=\"876\">876</a>|Cleardown Module not found.|  | | <a name=\"879\">879</a>|Portfolios do not have the same base currency|  | | <a name=\"880\">880</a>|There was a problem with the definition of the compliance expression.|  | | <a name=\"881\">881</a>|Block overplaced.|  | | <a name=\"882\">882</a>|Order not approved.|  | | <a name=\"883\">883</a>|Cannot update the shared fields of a block with associated orders.|  | | <a name=\"886\">886</a>|Cannot lock the period.|  | | <a name=\"887\">887</a>|Cannot apply clear down module.|  | | <a name=\"888\">888</a>|Cannot upsert Instrument Event Instruction.|  | | <a name=\"889\">889</a>|Cannot read Instrument Event Instruction.|  | | <a name=\"895\">895</a>|The Capital Ratio Calculation Is Wrong.|  | | <a name=\"910\">910</a>|Cannot update a block referenced by a placement.|  | | <a name=\"911\">911</a>|A Fund that references this Abor already exists.|  | | <a name=\"912\">912</a>|Cannot add decision to Staged Modification.|  | | <a name=\"913\">913</a>|The Staged Modification could not be applied.|  | | <a name=\"914\">914</a>|Action cannot be executed.|  | | <a name=\"915\">915</a>|Cannot upsert multiple versions of the same property in one request.|  | | <a name=\"916\">916</a>|Placement and direct descendents have more executed quantity than total placement quantity.|  | | <a name=\"917\">917</a>|Cannot update a placement with this EntryType.|  | | <a name=\"918\">918</a>|Cannot update a placement in this State.|  | | <a name=\"919\">919</a>|Placement could not be cancelled.|  | | <a name=\"920\">920</a>|Share Class not configured in Fund|  | | <a name=\"921\">921</a>|Share Class Sub Holding Key not configured in Portfolio|  | | <a name=\"922\">922</a>|Could not update an order.|  | | <a name=\"923\">923</a>|Multiple sets of Share Class Sub Holding Keys configured across the Portfolios of a Fund.|  | | <a name=\"924\">924</a>|One or more matrix cells could not be added to the matrix.|  | | <a name=\"925\">925</a>|There was a problem with the provided matrix definition.|  | | <a name=\"926\">926</a>|Matrix definition does not exist.|  | | <a name=\"927\">927</a>|Matrix definition could not be deleted because it doesn't exist.|  | 
 *
 * The version of the OpenAPI document: 1.1.432
 * Contact: info@finbourne.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Lusid.Sdk.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ILegacyComplianceApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// [EXPERIMENTAL] DeleteLegacyComplianceRule: Deletes a compliance rule.
        /// </summary>
        /// <remarks>
        /// Deletes the rule for all effective time.                The rule will remain viewable at previous as at times, and as part of the results of compliance runs, but it  will no longer be considered in new compliance runs.                This cannot be undone.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <returns>DeletedEntityResponse</returns>
        DeletedEntityResponse DeleteLegacyComplianceRule(string scope, string code);

        /// <summary>
        /// [EXPERIMENTAL] DeleteLegacyComplianceRule: Deletes a compliance rule.
        /// </summary>
        /// <remarks>
        /// Deletes the rule for all effective time.                The rule will remain viewable at previous as at times, and as part of the results of compliance runs, but it  will no longer be considered in new compliance runs.                This cannot be undone.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        ApiResponse<DeletedEntityResponse> DeleteLegacyComplianceRuleWithHttpInfo(string scope, string code);
        /// <summary>
        /// [EXPERIMENTAL] GetLegacyBreachedOrdersInfo: Get the Ids of Breached orders in a given compliance run and the corresponding list of rules that could have caused it.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to get a list or breached orders and the set of rules that may have caused the breach.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The RunId that the results should be checked for</param>
        /// <param name="orderScope">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="orderCode">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <returns>ResourceListOfComplianceBreachedOrderInfo</returns>
        ResourceListOfComplianceBreachedOrderInfo GetLegacyBreachedOrdersInfo(string runId, string orderScope = default(string), string orderCode = default(string), int? limit = default(int?));

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyBreachedOrdersInfo: Get the Ids of Breached orders in a given compliance run and the corresponding list of rules that could have caused it.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to get a list or breached orders and the set of rules that may have caused the breach.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The RunId that the results should be checked for</param>
        /// <param name="orderScope">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="orderCode">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <returns>ApiResponse of ResourceListOfComplianceBreachedOrderInfo</returns>
        ApiResponse<ResourceListOfComplianceBreachedOrderInfo> GetLegacyBreachedOrdersInfoWithHttpInfo(string runId, string orderScope = default(string), string orderCode = default(string), int? limit = default(int?));
        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRule: Retrieve the definition of single compliance rule.
        /// </summary>
        /// <remarks>
        /// Retrieves the compliance rule definition at the given effective and as at times.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definition. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definition. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <returns>ComplianceRule</returns>
        ComplianceRule GetLegacyComplianceRule(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?));

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRule: Retrieve the definition of single compliance rule.
        /// </summary>
        /// <remarks>
        /// Retrieves the compliance rule definition at the given effective and as at times.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definition. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definition. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <returns>ApiResponse of ComplianceRule</returns>
        ApiResponse<ComplianceRule> GetLegacyComplianceRuleWithHttpInfo(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?));
        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRunResults: Get the details of a single compliance run.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch the detail associated with a specific compliance run, including a breakdown  of the passing state of each rule, portfolio combination.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The unique identifier of the compliance run requested.</param>
        /// <param name="page">The pagination token to use to continue listing compliance rule results from a previous call to list compliance rule result.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <returns>ResourceListOfComplianceRuleResult</returns>
        ResourceListOfComplianceRuleResult GetLegacyComplianceRunResults(string runId, string page = default(string), int? limit = default(int?), string filter = default(string));

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRunResults: Get the details of a single compliance run.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch the detail associated with a specific compliance run, including a breakdown  of the passing state of each rule, portfolio combination.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The unique identifier of the compliance run requested.</param>
        /// <param name="page">The pagination token to use to continue listing compliance rule results from a previous call to list compliance rule result.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <returns>ApiResponse of ResourceListOfComplianceRuleResult</returns>
        ApiResponse<ResourceListOfComplianceRuleResult> GetLegacyComplianceRunResultsWithHttpInfo(string runId, string page = default(string), int? limit = default(int?), string filter = default(string));
        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRules: List compliance rules, with optional filtering.
        /// </summary>
        /// <remarks>
        /// For more information about filtering results,  see https://support.lusid.com/knowledgebase/article/KA-01914.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definitions. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definitions. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing entities; this value is returned from the previous call. If  a pagination token is provided, the filter, effectiveAt and asAt fields must not have changed since the  original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <returns>ResourceListOfComplianceRule</returns>
        ResourceListOfComplianceRule ListLegacyComplianceRules(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string));

        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRules: List compliance rules, with optional filtering.
        /// </summary>
        /// <remarks>
        /// For more information about filtering results,  see https://support.lusid.com/knowledgebase/article/KA-01914.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definitions. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definitions. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing entities; this value is returned from the previous call. If  a pagination token is provided, the filter, effectiveAt and asAt fields must not have changed since the  original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <returns>ApiResponse of ResourceListOfComplianceRule</returns>
        ApiResponse<ResourceListOfComplianceRule> ListLegacyComplianceRulesWithHttpInfo(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string));
        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRunInfo: List historical compliance run ids.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch a list of all historical compliance runs.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <returns>ResourceListOfComplianceRunInfo</returns>
        ResourceListOfComplianceRunInfo ListLegacyComplianceRunInfo(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string));

        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRunInfo: List historical compliance run ids.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch a list of all historical compliance runs.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <returns>ApiResponse of ResourceListOfComplianceRunInfo</returns>
        ApiResponse<ResourceListOfComplianceRunInfo> ListLegacyComplianceRunInfoWithHttpInfo(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string));
        /// <summary>
        /// [EXPERIMENTAL] RunLegacyCompliance: Kick off the compliance check process
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch the start a compliance run, based on a pre-set mapping file.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Optional: The code of the recipe to be used. If left blank, the default recipe will be used. (optional)</param>
        /// <param name="byTaxlots">Optional. (optional)</param>
        /// <returns>ComplianceRunInfo</returns>
        ComplianceRunInfo RunLegacyCompliance(bool isPreTrade, string recipeIdScope, string recipeIdCode = default(string), bool? byTaxlots = default(bool?));

        /// <summary>
        /// [EXPERIMENTAL] RunLegacyCompliance: Kick off the compliance check process
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch the start a compliance run, based on a pre-set mapping file.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Optional: The code of the recipe to be used. If left blank, the default recipe will be used. (optional)</param>
        /// <param name="byTaxlots">Optional. (optional)</param>
        /// <returns>ApiResponse of ComplianceRunInfo</returns>
        ApiResponse<ComplianceRunInfo> RunLegacyComplianceWithHttpInfo(bool isPreTrade, string recipeIdScope, string recipeIdCode = default(string), bool? byTaxlots = default(bool?));
        /// <summary>
        /// [EXPERIMENTAL] UpsertLegacyComplianceRules: Upsert compliance rules.
        /// </summary>
        /// <remarks>
        /// To upsert a new rule, the code field must be left empty, a code will then be assigned and returned as part  of the response. To update an existing rule, include the rule code. It is possible to both create and update  compliance rules in the same request.                The upsert is transactional - either all create/update operations will succeed or none of them will.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="requestBody">A dictionary of upsert request identifiers to rule upsert requests. The request               identifiers are valid for the request only and can be used to link the upserted compliance rule to the code               of a created compliance rule.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which the rule will take effect. Defaults to the current LUSID  system datetime if not specified. In the case of an update, the changes will take place from this effective  time until the next effective time that the rule as been upserted at. For example, consider a rule that  already exists, and has previously had an update applied so that the definition will change on the first day  of the coming month. An upsert effective from the current day will only change the definition until the  first day of the coming month. An additional upsert at the same time (first day of the month) is required  if the newly-updated definition is to supersede the future definition. (optional)</param>
        /// <returns>ComplianceRuleUpsertResponse</returns>
        ComplianceRuleUpsertResponse UpsertLegacyComplianceRules(Dictionary<string, ComplianceRuleUpsertRequest> requestBody, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel));

        /// <summary>
        /// [EXPERIMENTAL] UpsertLegacyComplianceRules: Upsert compliance rules.
        /// </summary>
        /// <remarks>
        /// To upsert a new rule, the code field must be left empty, a code will then be assigned and returned as part  of the response. To update an existing rule, include the rule code. It is possible to both create and update  compliance rules in the same request.                The upsert is transactional - either all create/update operations will succeed or none of them will.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="requestBody">A dictionary of upsert request identifiers to rule upsert requests. The request               identifiers are valid for the request only and can be used to link the upserted compliance rule to the code               of a created compliance rule.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which the rule will take effect. Defaults to the current LUSID  system datetime if not specified. In the case of an update, the changes will take place from this effective  time until the next effective time that the rule as been upserted at. For example, consider a rule that  already exists, and has previously had an update applied so that the definition will change on the first day  of the coming month. An upsert effective from the current day will only change the definition until the  first day of the coming month. An additional upsert at the same time (first day of the month) is required  if the newly-updated definition is to supersede the future definition. (optional)</param>
        /// <returns>ApiResponse of ComplianceRuleUpsertResponse</returns>
        ApiResponse<ComplianceRuleUpsertResponse> UpsertLegacyComplianceRulesWithHttpInfo(Dictionary<string, ComplianceRuleUpsertRequest> requestBody, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ILegacyComplianceApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// [EXPERIMENTAL] DeleteLegacyComplianceRule: Deletes a compliance rule.
        /// </summary>
        /// <remarks>
        /// Deletes the rule for all effective time.                The rule will remain viewable at previous as at times, and as part of the results of compliance runs, but it  will no longer be considered in new compliance runs.                This cannot be undone.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        System.Threading.Tasks.Task<DeletedEntityResponse> DeleteLegacyComplianceRuleAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] DeleteLegacyComplianceRule: Deletes a compliance rule.
        /// </summary>
        /// <remarks>
        /// Deletes the rule for all effective time.                The rule will remain viewable at previous as at times, and as part of the results of compliance runs, but it  will no longer be considered in new compliance runs.                This cannot be undone.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeletedEntityResponse>> DeleteLegacyComplianceRuleWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] GetLegacyBreachedOrdersInfo: Get the Ids of Breached orders in a given compliance run and the corresponding list of rules that could have caused it.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to get a list or breached orders and the set of rules that may have caused the breach.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The RunId that the results should be checked for</param>
        /// <param name="orderScope">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="orderCode">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ResourceListOfComplianceBreachedOrderInfo</returns>
        System.Threading.Tasks.Task<ResourceListOfComplianceBreachedOrderInfo> GetLegacyBreachedOrdersInfoAsync(string runId, string orderScope = default(string), string orderCode = default(string), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyBreachedOrdersInfo: Get the Ids of Breached orders in a given compliance run and the corresponding list of rules that could have caused it.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to get a list or breached orders and the set of rules that may have caused the breach.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The RunId that the results should be checked for</param>
        /// <param name="orderScope">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="orderCode">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ResourceListOfComplianceBreachedOrderInfo)</returns>
        System.Threading.Tasks.Task<ApiResponse<ResourceListOfComplianceBreachedOrderInfo>> GetLegacyBreachedOrdersInfoWithHttpInfoAsync(string runId, string orderScope = default(string), string orderCode = default(string), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRule: Retrieve the definition of single compliance rule.
        /// </summary>
        /// <remarks>
        /// Retrieves the compliance rule definition at the given effective and as at times.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definition. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definition. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRule</returns>
        System.Threading.Tasks.Task<ComplianceRule> GetLegacyComplianceRuleAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRule: Retrieve the definition of single compliance rule.
        /// </summary>
        /// <remarks>
        /// Retrieves the compliance rule definition at the given effective and as at times.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definition. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definition. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRule)</returns>
        System.Threading.Tasks.Task<ApiResponse<ComplianceRule>> GetLegacyComplianceRuleWithHttpInfoAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRunResults: Get the details of a single compliance run.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch the detail associated with a specific compliance run, including a breakdown  of the passing state of each rule, portfolio combination.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The unique identifier of the compliance run requested.</param>
        /// <param name="page">The pagination token to use to continue listing compliance rule results from a previous call to list compliance rule result.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ResourceListOfComplianceRuleResult</returns>
        System.Threading.Tasks.Task<ResourceListOfComplianceRuleResult> GetLegacyComplianceRunResultsAsync(string runId, string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRunResults: Get the details of a single compliance run.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch the detail associated with a specific compliance run, including a breakdown  of the passing state of each rule, portfolio combination.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The unique identifier of the compliance run requested.</param>
        /// <param name="page">The pagination token to use to continue listing compliance rule results from a previous call to list compliance rule result.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ResourceListOfComplianceRuleResult)</returns>
        System.Threading.Tasks.Task<ApiResponse<ResourceListOfComplianceRuleResult>> GetLegacyComplianceRunResultsWithHttpInfoAsync(string runId, string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRules: List compliance rules, with optional filtering.
        /// </summary>
        /// <remarks>
        /// For more information about filtering results,  see https://support.lusid.com/knowledgebase/article/KA-01914.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definitions. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definitions. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing entities; this value is returned from the previous call. If  a pagination token is provided, the filter, effectiveAt and asAt fields must not have changed since the  original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ResourceListOfComplianceRule</returns>
        System.Threading.Tasks.Task<ResourceListOfComplianceRule> ListLegacyComplianceRulesAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRules: List compliance rules, with optional filtering.
        /// </summary>
        /// <remarks>
        /// For more information about filtering results,  see https://support.lusid.com/knowledgebase/article/KA-01914.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definitions. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definitions. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing entities; this value is returned from the previous call. If  a pagination token is provided, the filter, effectiveAt and asAt fields must not have changed since the  original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ResourceListOfComplianceRule)</returns>
        System.Threading.Tasks.Task<ApiResponse<ResourceListOfComplianceRule>> ListLegacyComplianceRulesWithHttpInfoAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRunInfo: List historical compliance run ids.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch a list of all historical compliance runs.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ResourceListOfComplianceRunInfo</returns>
        System.Threading.Tasks.Task<ResourceListOfComplianceRunInfo> ListLegacyComplianceRunInfoAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRunInfo: List historical compliance run ids.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch a list of all historical compliance runs.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ResourceListOfComplianceRunInfo)</returns>
        System.Threading.Tasks.Task<ApiResponse<ResourceListOfComplianceRunInfo>> ListLegacyComplianceRunInfoWithHttpInfoAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] RunLegacyCompliance: Kick off the compliance check process
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch the start a compliance run, based on a pre-set mapping file.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Optional: The code of the recipe to be used. If left blank, the default recipe will be used. (optional)</param>
        /// <param name="byTaxlots">Optional. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRunInfo</returns>
        System.Threading.Tasks.Task<ComplianceRunInfo> RunLegacyComplianceAsync(bool isPreTrade, string recipeIdScope, string recipeIdCode = default(string), bool? byTaxlots = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] RunLegacyCompliance: Kick off the compliance check process
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch the start a compliance run, based on a pre-set mapping file.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Optional: The code of the recipe to be used. If left blank, the default recipe will be used. (optional)</param>
        /// <param name="byTaxlots">Optional. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRunInfo)</returns>
        System.Threading.Tasks.Task<ApiResponse<ComplianceRunInfo>> RunLegacyComplianceWithHttpInfoAsync(bool isPreTrade, string recipeIdScope, string recipeIdCode = default(string), bool? byTaxlots = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] UpsertLegacyComplianceRules: Upsert compliance rules.
        /// </summary>
        /// <remarks>
        /// To upsert a new rule, the code field must be left empty, a code will then be assigned and returned as part  of the response. To update an existing rule, include the rule code. It is possible to both create and update  compliance rules in the same request.                The upsert is transactional - either all create/update operations will succeed or none of them will.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="requestBody">A dictionary of upsert request identifiers to rule upsert requests. The request               identifiers are valid for the request only and can be used to link the upserted compliance rule to the code               of a created compliance rule.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which the rule will take effect. Defaults to the current LUSID  system datetime if not specified. In the case of an update, the changes will take place from this effective  time until the next effective time that the rule as been upserted at. For example, consider a rule that  already exists, and has previously had an update applied so that the definition will change on the first day  of the coming month. An upsert effective from the current day will only change the definition until the  first day of the coming month. An additional upsert at the same time (first day of the month) is required  if the newly-updated definition is to supersede the future definition. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRuleUpsertResponse</returns>
        System.Threading.Tasks.Task<ComplianceRuleUpsertResponse> UpsertLegacyComplianceRulesAsync(Dictionary<string, ComplianceRuleUpsertRequest> requestBody, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] UpsertLegacyComplianceRules: Upsert compliance rules.
        /// </summary>
        /// <remarks>
        /// To upsert a new rule, the code field must be left empty, a code will then be assigned and returned as part  of the response. To update an existing rule, include the rule code. It is possible to both create and update  compliance rules in the same request.                The upsert is transactional - either all create/update operations will succeed or none of them will.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="requestBody">A dictionary of upsert request identifiers to rule upsert requests. The request               identifiers are valid for the request only and can be used to link the upserted compliance rule to the code               of a created compliance rule.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which the rule will take effect. Defaults to the current LUSID  system datetime if not specified. In the case of an update, the changes will take place from this effective  time until the next effective time that the rule as been upserted at. For example, consider a rule that  already exists, and has previously had an update applied so that the definition will change on the first day  of the coming month. An upsert effective from the current day will only change the definition until the  first day of the coming month. An additional upsert at the same time (first day of the month) is required  if the newly-updated definition is to supersede the future definition. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRuleUpsertResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ComplianceRuleUpsertResponse>> UpsertLegacyComplianceRulesWithHttpInfoAsync(Dictionary<string, ComplianceRuleUpsertRequest> requestBody, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ILegacyComplianceApi : ILegacyComplianceApiSync, ILegacyComplianceApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class LegacyComplianceApi : ILegacyComplianceApi
    {
        private Lusid.Sdk.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyComplianceApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LegacyComplianceApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyComplianceApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LegacyComplianceApi(String basePath)
        {
            this.Configuration = Lusid.Sdk.Client.Configuration.MergeConfigurations(
                Lusid.Sdk.Client.GlobalConfiguration.Instance,
                new Lusid.Sdk.Client.Configuration { BasePath = basePath }
            );
            this.Client = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Lusid.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyComplianceApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public LegacyComplianceApi(Lusid.Sdk.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = configuration;
            this.Client = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Lusid.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyComplianceApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public LegacyComplianceApi(Lusid.Sdk.Client.ISynchronousClient client, Lusid.Sdk.Client.IAsynchronousClient asyncClient, Lusid.Sdk.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Lusid.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Lusid.Sdk.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Lusid.Sdk.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Lusid.Sdk.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Lusid.Sdk.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteLegacyComplianceRule: Deletes a compliance rule. Deletes the rule for all effective time.                The rule will remain viewable at previous as at times, and as part of the results of compliance runs, but it  will no longer be considered in new compliance runs.                This cannot be undone.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <returns>DeletedEntityResponse</returns>
        public DeletedEntityResponse DeleteLegacyComplianceRule(string scope, string code)
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = DeleteLegacyComplianceRuleWithHttpInfo(scope, code);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteLegacyComplianceRule: Deletes a compliance rule. Deletes the rule for all effective time.                The rule will remain viewable at previous as at times, and as part of the results of compliance runs, but it  will no longer be considered in new compliance runs.                This cannot be undone.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> DeleteLegacyComplianceRuleWithHttpInfo(string scope, string code)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling LegacyComplianceApi->DeleteLegacyComplianceRule");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling LegacyComplianceApi->DeleteLegacyComplianceRule");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request
            var localVarResponse = this.Client.Delete<DeletedEntityResponse>("/api/legacy/compliance/rules/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteLegacyComplianceRule", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteLegacyComplianceRule: Deletes a compliance rule. Deletes the rule for all effective time.                The rule will remain viewable at previous as at times, and as part of the results of compliance runs, but it  will no longer be considered in new compliance runs.                This cannot be undone.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        public async System.Threading.Tasks.Task<DeletedEntityResponse> DeleteLegacyComplianceRuleAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = await DeleteLegacyComplianceRuleWithHttpInfoAsync(scope, code, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteLegacyComplianceRule: Deletes a compliance rule. Deletes the rule for all effective time.                The rule will remain viewable at previous as at times, and as part of the results of compliance runs, but it  will no longer be considered in new compliance runs.                This cannot be undone.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse>> DeleteLegacyComplianceRuleWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling LegacyComplianceApi->DeleteLegacyComplianceRule");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling LegacyComplianceApi->DeleteLegacyComplianceRule");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<DeletedEntityResponse>("/api/legacy/compliance/rules/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteLegacyComplianceRule", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyBreachedOrdersInfo: Get the Ids of Breached orders in a given compliance run and the corresponding list of rules that could have caused it. Use this endpoint to get a list or breached orders and the set of rules that may have caused the breach.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The RunId that the results should be checked for</param>
        /// <param name="orderScope">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="orderCode">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <returns>ResourceListOfComplianceBreachedOrderInfo</returns>
        public ResourceListOfComplianceBreachedOrderInfo GetLegacyBreachedOrdersInfo(string runId, string orderScope = default(string), string orderCode = default(string), int? limit = default(int?))
        {
            Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceBreachedOrderInfo> localVarResponse = GetLegacyBreachedOrdersInfoWithHttpInfo(runId, orderScope, orderCode, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyBreachedOrdersInfo: Get the Ids of Breached orders in a given compliance run and the corresponding list of rules that could have caused it. Use this endpoint to get a list or breached orders and the set of rules that may have caused the breach.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The RunId that the results should be checked for</param>
        /// <param name="orderScope">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="orderCode">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <returns>ApiResponse of ResourceListOfComplianceBreachedOrderInfo</returns>
        public Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceBreachedOrderInfo> GetLegacyBreachedOrdersInfoWithHttpInfo(string runId, string orderScope = default(string), string orderCode = default(string), int? limit = default(int?))
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'runId' when calling LegacyComplianceApi->GetLegacyBreachedOrdersInfo");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("runId", Lusid.Sdk.Client.ClientUtils.ParameterToString(runId)); // path parameter
            if (orderScope != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "orderScope", orderScope));
            }
            if (orderCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "orderCode", orderCode));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request
            var localVarResponse = this.Client.Get<ResourceListOfComplianceBreachedOrderInfo>("/api/legacy/compliance/runs/breached/{runId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLegacyBreachedOrdersInfo", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyBreachedOrdersInfo: Get the Ids of Breached orders in a given compliance run and the corresponding list of rules that could have caused it. Use this endpoint to get a list or breached orders and the set of rules that may have caused the breach.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The RunId that the results should be checked for</param>
        /// <param name="orderScope">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="orderCode">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ResourceListOfComplianceBreachedOrderInfo</returns>
        public async System.Threading.Tasks.Task<ResourceListOfComplianceBreachedOrderInfo> GetLegacyBreachedOrdersInfoAsync(string runId, string orderScope = default(string), string orderCode = default(string), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceBreachedOrderInfo> localVarResponse = await GetLegacyBreachedOrdersInfoWithHttpInfoAsync(runId, orderScope, orderCode, limit, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyBreachedOrdersInfo: Get the Ids of Breached orders in a given compliance run and the corresponding list of rules that could have caused it. Use this endpoint to get a list or breached orders and the set of rules that may have caused the breach.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The RunId that the results should be checked for</param>
        /// <param name="orderScope">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="orderCode">Optional. Find rules related to a specific order by providing an Order Scope/Code combination (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ResourceListOfComplianceBreachedOrderInfo)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceBreachedOrderInfo>> GetLegacyBreachedOrdersInfoWithHttpInfoAsync(string runId, string orderScope = default(string), string orderCode = default(string), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'runId' when calling LegacyComplianceApi->GetLegacyBreachedOrdersInfo");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("runId", Lusid.Sdk.Client.ClientUtils.ParameterToString(runId)); // path parameter
            if (orderScope != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "orderScope", orderScope));
            }
            if (orderCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "orderCode", orderCode));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ResourceListOfComplianceBreachedOrderInfo>("/api/legacy/compliance/runs/breached/{runId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLegacyBreachedOrdersInfo", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRule: Retrieve the definition of single compliance rule. Retrieves the compliance rule definition at the given effective and as at times.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definition. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definition. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <returns>ComplianceRule</returns>
        public ComplianceRule GetLegacyComplianceRule(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRule> localVarResponse = GetLegacyComplianceRuleWithHttpInfo(scope, code, effectiveAt, asAt);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRule: Retrieve the definition of single compliance rule. Retrieves the compliance rule definition at the given effective and as at times.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definition. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definition. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <returns>ApiResponse of ComplianceRule</returns>
        public Lusid.Sdk.Client.ApiResponse<ComplianceRule> GetLegacyComplianceRuleWithHttpInfo(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling LegacyComplianceApi->GetLegacyComplianceRule");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling LegacyComplianceApi->GetLegacyComplianceRule");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request
            var localVarResponse = this.Client.Get<ComplianceRule>("/api/legacy/compliance/rules/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLegacyComplianceRule", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRule: Retrieve the definition of single compliance rule. Retrieves the compliance rule definition at the given effective and as at times.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definition. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definition. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRule</returns>
        public async System.Threading.Tasks.Task<ComplianceRule> GetLegacyComplianceRuleAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRule> localVarResponse = await GetLegacyComplianceRuleWithHttpInfoAsync(scope, code, effectiveAt, asAt, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRule: Retrieve the definition of single compliance rule. Retrieves the compliance rule definition at the given effective and as at times.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule scope.</param>
        /// <param name="code">The compliance rule code.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definition. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definition. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRule)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ComplianceRule>> GetLegacyComplianceRuleWithHttpInfoAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling LegacyComplianceApi->GetLegacyComplianceRule");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling LegacyComplianceApi->GetLegacyComplianceRule");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ComplianceRule>("/api/legacy/compliance/rules/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLegacyComplianceRule", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRunResults: Get the details of a single compliance run. Use this endpoint to fetch the detail associated with a specific compliance run, including a breakdown  of the passing state of each rule, portfolio combination.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The unique identifier of the compliance run requested.</param>
        /// <param name="page">The pagination token to use to continue listing compliance rule results from a previous call to list compliance rule result.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <returns>ResourceListOfComplianceRuleResult</returns>
        public ResourceListOfComplianceRuleResult GetLegacyComplianceRunResults(string runId, string page = default(string), int? limit = default(int?), string filter = default(string))
        {
            Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceRuleResult> localVarResponse = GetLegacyComplianceRunResultsWithHttpInfo(runId, page, limit, filter);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRunResults: Get the details of a single compliance run. Use this endpoint to fetch the detail associated with a specific compliance run, including a breakdown  of the passing state of each rule, portfolio combination.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The unique identifier of the compliance run requested.</param>
        /// <param name="page">The pagination token to use to continue listing compliance rule results from a previous call to list compliance rule result.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <returns>ApiResponse of ResourceListOfComplianceRuleResult</returns>
        public Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceRuleResult> GetLegacyComplianceRunResultsWithHttpInfo(string runId, string page = default(string), int? limit = default(int?), string filter = default(string))
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'runId' when calling LegacyComplianceApi->GetLegacyComplianceRunResults");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("runId", Lusid.Sdk.Client.ClientUtils.ParameterToString(runId)); // path parameter
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request
            var localVarResponse = this.Client.Get<ResourceListOfComplianceRuleResult>("/api/legacy/compliance/runs/{runId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLegacyComplianceRunResults", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRunResults: Get the details of a single compliance run. Use this endpoint to fetch the detail associated with a specific compliance run, including a breakdown  of the passing state of each rule, portfolio combination.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The unique identifier of the compliance run requested.</param>
        /// <param name="page">The pagination token to use to continue listing compliance rule results from a previous call to list compliance rule result.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ResourceListOfComplianceRuleResult</returns>
        public async System.Threading.Tasks.Task<ResourceListOfComplianceRuleResult> GetLegacyComplianceRunResultsAsync(string runId, string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceRuleResult> localVarResponse = await GetLegacyComplianceRunResultsWithHttpInfoAsync(runId, page, limit, filter, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetLegacyComplianceRunResults: Get the details of a single compliance run. Use this endpoint to fetch the detail associated with a specific compliance run, including a breakdown  of the passing state of each rule, portfolio combination.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">The unique identifier of the compliance run requested.</param>
        /// <param name="page">The pagination token to use to continue listing compliance rule results from a previous call to list compliance rule result.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ResourceListOfComplianceRuleResult)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceRuleResult>> GetLegacyComplianceRunResultsWithHttpInfoAsync(string runId, string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'runId' when calling LegacyComplianceApi->GetLegacyComplianceRunResults");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("runId", Lusid.Sdk.Client.ClientUtils.ParameterToString(runId)); // path parameter
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ResourceListOfComplianceRuleResult>("/api/legacy/compliance/runs/{runId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLegacyComplianceRunResults", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRules: List compliance rules, with optional filtering. For more information about filtering results,  see https://support.lusid.com/knowledgebase/article/KA-01914.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definitions. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definitions. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing entities; this value is returned from the previous call. If  a pagination token is provided, the filter, effectiveAt and asAt fields must not have changed since the  original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <returns>ResourceListOfComplianceRule</returns>
        public ResourceListOfComplianceRule ListLegacyComplianceRules(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string))
        {
            Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceRule> localVarResponse = ListLegacyComplianceRulesWithHttpInfo(effectiveAt, asAt, page, limit, filter);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRules: List compliance rules, with optional filtering. For more information about filtering results,  see https://support.lusid.com/knowledgebase/article/KA-01914.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definitions. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definitions. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing entities; this value is returned from the previous call. If  a pagination token is provided, the filter, effectiveAt and asAt fields must not have changed since the  original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <returns>ApiResponse of ResourceListOfComplianceRule</returns>
        public Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceRule> ListLegacyComplianceRulesWithHttpInfo(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request
            var localVarResponse = this.Client.Get<ResourceListOfComplianceRule>("/api/legacy/compliance/rules", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListLegacyComplianceRules", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRules: List compliance rules, with optional filtering. For more information about filtering results,  see https://support.lusid.com/knowledgebase/article/KA-01914.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definitions. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definitions. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing entities; this value is returned from the previous call. If  a pagination token is provided, the filter, effectiveAt and asAt fields must not have changed since the  original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ResourceListOfComplianceRule</returns>
        public async System.Threading.Tasks.Task<ResourceListOfComplianceRule> ListLegacyComplianceRulesAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceRule> localVarResponse = await ListLegacyComplianceRulesWithHttpInfoAsync(effectiveAt, asAt, page, limit, filter, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRules: List compliance rules, with optional filtering. For more information about filtering results,  see https://support.lusid.com/knowledgebase/article/KA-01914.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the rule definitions. Defaults to the current LUSID  system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the rule definitions. Defaults to returning the latest version if not  specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing entities; this value is returned from the previous call. If  a pagination token is provided, the filter, effectiveAt and asAt fields must not have changed since the  original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ResourceListOfComplianceRule)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceRule>> ListLegacyComplianceRulesWithHttpInfoAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ResourceListOfComplianceRule>("/api/legacy/compliance/rules", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListLegacyComplianceRules", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRunInfo: List historical compliance run ids. Use this endpoint to fetch a list of all historical compliance runs.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <returns>ResourceListOfComplianceRunInfo</returns>
        public ResourceListOfComplianceRunInfo ListLegacyComplianceRunInfo(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string))
        {
            Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceRunInfo> localVarResponse = ListLegacyComplianceRunInfoWithHttpInfo(asAt, page, limit, filter);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRunInfo: List historical compliance run ids. Use this endpoint to fetch a list of all historical compliance runs.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <returns>ApiResponse of ResourceListOfComplianceRunInfo</returns>
        public Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceRunInfo> ListLegacyComplianceRunInfoWithHttpInfo(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request
            var localVarResponse = this.Client.Get<ResourceListOfComplianceRunInfo>("/api/legacy/compliance/runs", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListLegacyComplianceRunInfo", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRunInfo: List historical compliance run ids. Use this endpoint to fetch a list of all historical compliance runs.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ResourceListOfComplianceRunInfo</returns>
        public async System.Threading.Tasks.Task<ResourceListOfComplianceRunInfo> ListLegacyComplianceRunInfoAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceRunInfo> localVarResponse = await ListLegacyComplianceRunInfoWithHttpInfoAsync(asAt, page, limit, filter, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListLegacyComplianceRunInfo: List historical compliance run ids. Use this endpoint to fetch a list of all historical compliance runs.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ResourceListOfComplianceRunInfo)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ResourceListOfComplianceRunInfo>> ListLegacyComplianceRunInfoWithHttpInfoAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ResourceListOfComplianceRunInfo>("/api/legacy/compliance/runs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListLegacyComplianceRunInfo", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] RunLegacyCompliance: Kick off the compliance check process Use this endpoint to fetch the start a compliance run, based on a pre-set mapping file.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Optional: The code of the recipe to be used. If left blank, the default recipe will be used. (optional)</param>
        /// <param name="byTaxlots">Optional. (optional)</param>
        /// <returns>ComplianceRunInfo</returns>
        public ComplianceRunInfo RunLegacyCompliance(bool isPreTrade, string recipeIdScope, string recipeIdCode = default(string), bool? byTaxlots = default(bool?))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRunInfo> localVarResponse = RunLegacyComplianceWithHttpInfo(isPreTrade, recipeIdScope, recipeIdCode, byTaxlots);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] RunLegacyCompliance: Kick off the compliance check process Use this endpoint to fetch the start a compliance run, based on a pre-set mapping file.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Optional: The code of the recipe to be used. If left blank, the default recipe will be used. (optional)</param>
        /// <param name="byTaxlots">Optional. (optional)</param>
        /// <returns>ApiResponse of ComplianceRunInfo</returns>
        public Lusid.Sdk.Client.ApiResponse<ComplianceRunInfo> RunLegacyComplianceWithHttpInfo(bool isPreTrade, string recipeIdScope, string recipeIdCode = default(string), bool? byTaxlots = default(bool?))
        {
            // verify the required parameter 'recipeIdScope' is set
            if (recipeIdScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'recipeIdScope' when calling LegacyComplianceApi->RunLegacyCompliance");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "isPreTrade", isPreTrade));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "recipeIdScope", recipeIdScope));
            if (recipeIdCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "recipeIdCode", recipeIdCode));
            }
            if (byTaxlots != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "byTaxlots", byTaxlots));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ComplianceRunInfo>("/api/legacy/compliance/runs", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("RunLegacyCompliance", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] RunLegacyCompliance: Kick off the compliance check process Use this endpoint to fetch the start a compliance run, based on a pre-set mapping file.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Optional: The code of the recipe to be used. If left blank, the default recipe will be used. (optional)</param>
        /// <param name="byTaxlots">Optional. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRunInfo</returns>
        public async System.Threading.Tasks.Task<ComplianceRunInfo> RunLegacyComplianceAsync(bool isPreTrade, string recipeIdScope, string recipeIdCode = default(string), bool? byTaxlots = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRunInfo> localVarResponse = await RunLegacyComplianceWithHttpInfoAsync(isPreTrade, recipeIdScope, recipeIdCode, byTaxlots, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] RunLegacyCompliance: Kick off the compliance check process Use this endpoint to fetch the start a compliance run, based on a pre-set mapping file.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Optional: The code of the recipe to be used. If left blank, the default recipe will be used. (optional)</param>
        /// <param name="byTaxlots">Optional. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRunInfo)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ComplianceRunInfo>> RunLegacyComplianceWithHttpInfoAsync(bool isPreTrade, string recipeIdScope, string recipeIdCode = default(string), bool? byTaxlots = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'recipeIdScope' is set
            if (recipeIdScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'recipeIdScope' when calling LegacyComplianceApi->RunLegacyCompliance");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "isPreTrade", isPreTrade));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "recipeIdScope", recipeIdScope));
            if (recipeIdCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "recipeIdCode", recipeIdCode));
            }
            if (byTaxlots != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "byTaxlots", byTaxlots));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ComplianceRunInfo>("/api/legacy/compliance/runs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("RunLegacyCompliance", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertLegacyComplianceRules: Upsert compliance rules. To upsert a new rule, the code field must be left empty, a code will then be assigned and returned as part  of the response. To update an existing rule, include the rule code. It is possible to both create and update  compliance rules in the same request.                The upsert is transactional - either all create/update operations will succeed or none of them will.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="requestBody">A dictionary of upsert request identifiers to rule upsert requests. The request               identifiers are valid for the request only and can be used to link the upserted compliance rule to the code               of a created compliance rule.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which the rule will take effect. Defaults to the current LUSID  system datetime if not specified. In the case of an update, the changes will take place from this effective  time until the next effective time that the rule as been upserted at. For example, consider a rule that  already exists, and has previously had an update applied so that the definition will change on the first day  of the coming month. An upsert effective from the current day will only change the definition until the  first day of the coming month. An additional upsert at the same time (first day of the month) is required  if the newly-updated definition is to supersede the future definition. (optional)</param>
        /// <returns>ComplianceRuleUpsertResponse</returns>
        public ComplianceRuleUpsertResponse UpsertLegacyComplianceRules(Dictionary<string, ComplianceRuleUpsertRequest> requestBody, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRuleUpsertResponse> localVarResponse = UpsertLegacyComplianceRulesWithHttpInfo(requestBody, effectiveAt);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertLegacyComplianceRules: Upsert compliance rules. To upsert a new rule, the code field must be left empty, a code will then be assigned and returned as part  of the response. To update an existing rule, include the rule code. It is possible to both create and update  compliance rules in the same request.                The upsert is transactional - either all create/update operations will succeed or none of them will.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="requestBody">A dictionary of upsert request identifiers to rule upsert requests. The request               identifiers are valid for the request only and can be used to link the upserted compliance rule to the code               of a created compliance rule.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which the rule will take effect. Defaults to the current LUSID  system datetime if not specified. In the case of an update, the changes will take place from this effective  time until the next effective time that the rule as been upserted at. For example, consider a rule that  already exists, and has previously had an update applied so that the definition will change on the first day  of the coming month. An upsert effective from the current day will only change the definition until the  first day of the coming month. An additional upsert at the same time (first day of the month) is required  if the newly-updated definition is to supersede the future definition. (optional)</param>
        /// <returns>ApiResponse of ComplianceRuleUpsertResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<ComplianceRuleUpsertResponse> UpsertLegacyComplianceRulesWithHttpInfo(Dictionary<string, ComplianceRuleUpsertRequest> requestBody, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel))
        {
            // verify the required parameter 'requestBody' is set
            if (requestBody == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'requestBody' when calling LegacyComplianceApi->UpsertLegacyComplianceRules");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            localVarRequestOptions.Data = requestBody;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ComplianceRuleUpsertResponse>("/api/legacy/compliance/rules", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertLegacyComplianceRules", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertLegacyComplianceRules: Upsert compliance rules. To upsert a new rule, the code field must be left empty, a code will then be assigned and returned as part  of the response. To update an existing rule, include the rule code. It is possible to both create and update  compliance rules in the same request.                The upsert is transactional - either all create/update operations will succeed or none of them will.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="requestBody">A dictionary of upsert request identifiers to rule upsert requests. The request               identifiers are valid for the request only and can be used to link the upserted compliance rule to the code               of a created compliance rule.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which the rule will take effect. Defaults to the current LUSID  system datetime if not specified. In the case of an update, the changes will take place from this effective  time until the next effective time that the rule as been upserted at. For example, consider a rule that  already exists, and has previously had an update applied so that the definition will change on the first day  of the coming month. An upsert effective from the current day will only change the definition until the  first day of the coming month. An additional upsert at the same time (first day of the month) is required  if the newly-updated definition is to supersede the future definition. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRuleUpsertResponse</returns>
        public async System.Threading.Tasks.Task<ComplianceRuleUpsertResponse> UpsertLegacyComplianceRulesAsync(Dictionary<string, ComplianceRuleUpsertRequest> requestBody, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRuleUpsertResponse> localVarResponse = await UpsertLegacyComplianceRulesWithHttpInfoAsync(requestBody, effectiveAt, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertLegacyComplianceRules: Upsert compliance rules. To upsert a new rule, the code field must be left empty, a code will then be assigned and returned as part  of the response. To update an existing rule, include the rule code. It is possible to both create and update  compliance rules in the same request.                The upsert is transactional - either all create/update operations will succeed or none of them will.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="requestBody">A dictionary of upsert request identifiers to rule upsert requests. The request               identifiers are valid for the request only and can be used to link the upserted compliance rule to the code               of a created compliance rule.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which the rule will take effect. Defaults to the current LUSID  system datetime if not specified. In the case of an update, the changes will take place from this effective  time until the next effective time that the rule as been upserted at. For example, consider a rule that  already exists, and has previously had an update applied so that the definition will change on the first day  of the coming month. An upsert effective from the current day will only change the definition until the  first day of the coming month. An additional upsert at the same time (first day of the month) is required  if the newly-updated definition is to supersede the future definition. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRuleUpsertResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ComplianceRuleUpsertResponse>> UpsertLegacyComplianceRulesWithHttpInfoAsync(Dictionary<string, ComplianceRuleUpsertRequest> requestBody, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'requestBody' is set
            if (requestBody == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'requestBody' when calling LegacyComplianceApi->UpsertLegacyComplianceRules");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            localVarRequestOptions.Data = requestBody;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.432");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ComplianceRuleUpsertResponse>("/api/legacy/compliance/rules", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertLegacyComplianceRules", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}