/**
 * This configuration was generated using the CKEditor 5 Builder. You can modify it anytime using this link:
 * https://ckeditor.com/ckeditor-5/builder/?redirect=portal#installation/NoRgrANARATAdATjiK0AcYBsYDsBmPBPEBAFkxDxjzBKM2LIAZriZxq0cywDMZSqKABcATqjwRQEEBCYyFIALrQApjlUBDJnkxQlQA==
 */

import {
	DecoupledEditor,
	Autosave,
	Essentials,
	Paragraph,
	CloudServices,
	Autoformat,
	TextTransformation,
	LinkImage,
	Link,
	ImageBlock,
	ImageToolbar,
	BlockQuote,
	Bold,
	Bookmark,
	CKBox,
	ImageUpload,
	ImageInsert,
	ImageInsertViaUrl,
	AutoImage,
	PictureEditing,
	CKBoxImageEdit,
	CodeBlock,
	TableColumnResize,
	Table,
	TableToolbar,
	Emoji,
	Mention,
	PasteFromOffice,
	FindAndReplace,
	FontBackgroundColor,
	FontColor,
	FontFamily,
	FontSize,
	Fullscreen,
	Heading,
	HorizontalLine,
	ImageCaption,
	ImageResize,
	ImageStyle,
	Indent,
	IndentBlock,
	Code,
	Italic,
	AutoLink,
	ListProperties,
	List,
	MediaEmbed,
	RemoveFormat,
	SpecialCharactersArrows,
	SpecialCharacters,
	SpecialCharactersCurrency,
	SpecialCharactersEssentials,
	SpecialCharactersLatin,
	SpecialCharactersMathematical,
	SpecialCharactersText,
	Strikethrough,
	Subscript,
	Superscript,
	TableCaption,
	TableCellProperties,
	TableProperties,
	Alignment,
	TodoList,
	Underline,
	BalloonToolbar
} from 'ckeditor5';
import {
	AIChat,
	AIEditorIntegration,
	AIQuickActions,
	AIReviewMode,
	PasteFromOfficeEnhanced,
	FormatPainter,
	LineHeight,
	RealTimeCollaborativeComments,
	RealTimeCollaborativeEditing,
	PresenceList,
	Comments,
	RealTimeCollaborativeTrackChanges,
	TrackChanges,
	TrackChangesData,
	TrackChangesPreview,
	SlashCommand
} from 'ckeditor5-premium-features';

import translations from 'ckeditor5/translations/tr.js';
import premiumFeaturesTranslations from 'ckeditor5-premium-features/translations/tr.js';

const LICENSE_KEY =
	'eyJhbGciOiJFUzI1NiJ9.eyJleHAiOjE3NzA1OTUxOTksImp0aSI6IjI3OTA2Yjk5LWEyYzktNGE2NC04ZmM1LWViYzllNDZiNWZhNSIsInVzYWdlRW5kcG9pbnQiOiJodHRwczovL3Byb3h5LWV2ZW50LmNrZWRpdG9yLmNvbSIsImRpc3RyaWJ1dGlvbkNoYW5uZWwiOlsiY2xvdWQiLCJkcnVwYWwiLCJzaCJdLCJ3aGl0ZUxhYmVsIjp0cnVlLCJsaWNlbnNlVHlwZSI6InRyaWFsIiwiZmVhdHVyZXMiOlsiKiJdLCJ2YyI6IjkwZWNhMjE5In0.L_Z0CWA94LzkqIWHZwM4x17OLiIN1YPGczRUIv9hI_0VVNQlhdKAWH9fUYy95ksng1yLN3LfD-98g2mg3v8Lpw';

/**
 * Unique ID that will be used to identify this document. E.g. you may use ID taken from your database.
 * Read more: https://ckeditor.com/docs/ckeditor5/latest/api/module_collaboration-core_config-RealTimeCollaborationConfig.html
 */
const DOCUMENT_ID = '<YOUR_DOCUMENT_ID>';

const CLOUD_SERVICES_TOKEN_URL =
	'https://k4rzp92a15iy.cke-cs.com/token/dev/84fb3d7ca62f5b5ab90d6db727899c0adb759525cb410996f5b60b53d60a?limit=10';
const CLOUD_SERVICES_WEBSOCKET_URL = 'wss://k4rzp92a15iy.cke-cs.com/ws';

const editorConfig = {
	toolbar: {
		items: [
			'undo',
			'redo',
			'|',
			'trackChanges',
			'comment',
			'commentsArchive',
			'|',
			'toggleAi',
			'aiQuickActions',
			'|',
			'formatPainter',
			'findAndReplace',
			'fullscreen',
			'|',
			'heading',
			'|',
			'fontSize',
			'fontFamily',
			'fontColor',
			'fontBackgroundColor',
			'|',
			'bold',
			'italic',
			'underline',
			'strikethrough',
			'subscript',
			'superscript',
			'code',
			'removeFormat',
			'|',
			'emoji',
			'specialCharacters',
			'horizontalLine',
			'link',
			'bookmark',
			'insertImage',
			'insertImageViaUrl',
			'ckbox',
			'mediaEmbed',
			'insertTable',
			'blockQuote',
			'codeBlock',
			'|',
			'alignment',
			'lineHeight',
			'|',
			'bulletedList',
			'numberedList',
			'todoList',
			'outdent',
			'indent'
		],
		shouldNotGroupWhenFull: false
	},
	plugins: [
		AIChat,
		AIEditorIntegration,
		AIQuickActions,
		AIReviewMode,
		Alignment,
		Autoformat,
		AutoImage,
		AutoLink,
		Autosave,
		BalloonToolbar,
		BlockQuote,
		Bold,
		Bookmark,
		CKBox,
		CKBoxImageEdit,
		CloudServices,
		Code,
		CodeBlock,
		Comments,
		Emoji,
		Essentials,
		FindAndReplace,
		FontBackgroundColor,
		FontColor,
		FontFamily,
		FontSize,
		FormatPainter,
		Fullscreen,
		Heading,
		HorizontalLine,
		ImageBlock,
		ImageCaption,
		ImageInsert,
		ImageInsertViaUrl,
		ImageResize,
		ImageStyle,
		ImageToolbar,
		ImageUpload,
		Indent,
		IndentBlock,
		Italic,
		LineHeight,
		Link,
		LinkImage,
		List,
		ListProperties,
		MediaEmbed,
		Mention,
		Paragraph,
		PasteFromOffice,
		PasteFromOfficeEnhanced,
		PictureEditing,
		PresenceList,
		RealTimeCollaborativeComments,
		RealTimeCollaborativeEditing,
		RealTimeCollaborativeTrackChanges,
		RemoveFormat,
		SlashCommand,
		SpecialCharacters,
		SpecialCharactersArrows,
		SpecialCharactersCurrency,
		SpecialCharactersEssentials,
		SpecialCharactersLatin,
		SpecialCharactersMathematical,
		SpecialCharactersText,
		Strikethrough,
		Subscript,
		Superscript,
		Table,
		TableCaption,
		TableCellProperties,
		TableColumnResize,
		TableProperties,
		TableToolbar,
		TextTransformation,
		TodoList,
		TrackChanges,
		TrackChangesData,
		TrackChangesPreview,
		Underline
	],
	ai: {
		container: {
			type: 'sidebar',
			element: document.querySelector('#editor-ckeditor-ai'),
			showResizeButton: false
		},
		chat: {
			context: {
				document: {
					enabled: true
				},
				urls: {
					enabled: true
				},
				files: {
					enabled: true
				}
			}
		}
	},
	balloonToolbar: [
		'comment',
		'|',
		'aiQuickActions',
		'|',
		'bold',
		'italic',
		'|',
		'link',
		'insertImage',
		'|',
		'bulletedList',
		'numberedList'
	],
	cloudServices: {
		tokenUrl: CLOUD_SERVICES_TOKEN_URL,
		webSocketUrl: CLOUD_SERVICES_WEBSOCKET_URL
	},
	collaboration: {
		channelId: DOCUMENT_ID
	},
	comments: {
		editorConfig: {
			extraPlugins: [Autoformat, Bold, Italic, List, Mention],
			mention: {
				feeds: [
					{
						marker: '@',
						feed: [
							/* See: https://ckeditor.com/docs/ckeditor5/latest/features/mentions.html#comments-with-mentions */
						]
					}
				]
			}
		}
	},
	fontFamily: {
		supportAllValues: true
	},
	fontSize: {
		options: [10, 12, 14, 'default', 18, 20, 22],
		supportAllValues: true
	},
	fullscreen: {
		onEnterCallback: container =>
			container.classList.add(
				'editor-container',
				'editor-container_document-editor',
				'editor-container_include-annotations',
				'editor-container_contains-wrapper',
				'editor-container_include-fullscreen',
				'main-container'
			)
	},
	heading: {
		options: [
			{
				model: 'paragraph',
				title: 'Paragraph',
				class: 'ck-heading_paragraph'
			},
			{
				model: 'heading1',
				view: 'h1',
				title: 'Heading 1',
				class: 'ck-heading_heading1'
			},
			{
				model: 'heading2',
				view: 'h2',
				title: 'Heading 2',
				class: 'ck-heading_heading2'
			},
			{
				model: 'heading3',
				view: 'h3',
				title: 'Heading 3',
				class: 'ck-heading_heading3'
			},
			{
				model: 'heading4',
				view: 'h4',
				title: 'Heading 4',
				class: 'ck-heading_heading4'
			},
			{
				model: 'heading5',
				view: 'h5',
				title: 'Heading 5',
				class: 'ck-heading_heading5'
			},
			{
				model: 'heading6',
				view: 'h6',
				title: 'Heading 6',
				class: 'ck-heading_heading6'
			}
		]
	},
	image: {
		toolbar: [
			'toggleImageCaption',
			'|',
			'imageStyle:alignBlockLeft',
			'imageStyle:block',
			'imageStyle:alignBlockRight',
			'|',
			'resizeImage',
			'|',
			'ckboxImageEdit'
		],
		styles: {
			options: ['alignBlockLeft', 'block', 'alignBlockRight']
		}
	},
	initialData:
		'<h2>Congratulations on setting up CKEditor 5! 🎉</h2>\n<p>\n\tYou\'ve successfully created a CKEditor 5 project. This powerful text editor\n\twill enhance your application, enabling rich text editing capabilities that\n\tare customizable and easy to use.\n</p>\n<h3>What\'s next?</h3>\n<ol>\n\t<li>\n\t\t<strong>Integrate into your app</strong>: time to bring the editing into\n\t\tyour application. Take the code you created and add to your application.\n\t</li>\n\t<li>\n\t\t<strong>Explore features:</strong> Experiment with different plugins and\n\t\ttoolbar options to discover what works best for your needs.\n\t</li>\n\t<li>\n\t\t<strong>Customize your editor:</strong> Tailor the editor\'s\n\t\tconfiguration to match your application\'s style and requirements. Or\n\t\teven write your plugin!\n\t</li>\n</ol>\n<p>\n\tKeep experimenting, and don\'t hesitate to push the boundaries of what you\n\tcan achieve with CKEditor 5. Your feedback is invaluable to us as we strive\n\tto improve and evolve. Happy editing!\n</p>\n<h3>Helpful resources</h3>\n<ul>\n\t<li>📝 <a href="https://portal.ckeditor.com/checkout?plan=free">Trial sign up</a>,</li>\n\t<li>📕 <a href="https://ckeditor.com/docs/ckeditor5/latest/installation/index.html">Documentation</a>,</li>\n\t<li>⭐️ <a href="https://github.com/ckeditor/ckeditor5">GitHub</a> (star us if you can!),</li>\n\t<li>🏠 <a href="https://ckeditor.com">CKEditor Homepage</a>,</li>\n\t<li>🧑‍💻 <a href="https://ckeditor.com/ckeditor-5/demo/">CKEditor 5 Demos</a>,</li>\n</ul>\n<h3>Need help?</h3>\n<p>\n\tSee this text, but the editor is not starting up? Check the browser\'s\n\tconsole for clues and guidance. It may be related to an incorrect license\n\tkey if you use premium features or another feature-related requirement. If\n\tyou cannot make it work, file a GitHub issue, and we will help as soon as\n\tpossible!\n</p>\n',
	language: 'tr',
	licenseKey: LICENSE_KEY,
	lineHeight: {
		supportAllValues: true
	},
	link: {
		addTargetToExternalLinks: true,
		defaultProtocol: 'https://',
		decorators: {
			toggleDownloadable: {
				mode: 'manual',
				label: 'Downloadable',
				attributes: {
					download: 'file'
				}
			}
		}
	},
	list: {
		properties: {
			styles: true,
			startIndex: true,
			reversed: true
		}
	},
	mention: {
		feeds: [
			{
				marker: '@',
				feed: [
					/* See: https://ckeditor.com/docs/ckeditor5/latest/features/mentions.html */
				]
			}
		]
	},
	placeholder: 'Type or paste your content here!',
	presenceList: {
		container: document.querySelector('#editor-presence')
	},
	sidebar: {
		container: document.querySelector('#editor-annotations')
	},
	table: {
		contentToolbar: ['tableColumn', 'tableRow', 'mergeTableCells', 'tableProperties', 'tableCellProperties']
	},
	translations: [translations, premiumFeaturesTranslations]
};

configUpdateAlert(editorConfig);

DecoupledEditor.create(document.querySelector('#editor'), editorConfig).then(editor => {
	document.querySelector('#editor-toolbar').appendChild(editor.ui.view.toolbar.element);
	document.querySelector('#editor-menu-bar').appendChild(editor.ui.view.menuBarView.element);

	// Switch the annotations UI to the narrow sidebar layout. If you remove this,
	// ensure that the container does not use the `editor-container__sidebar_narrow` CSS class,
	// since it corresponds to this display mode.
	editor.plugins.get('AnnotationsUIs').switchTo('narrowSidebar');

	return editor;
});

/**
 * This function exists to remind you to update the config needed for premium features.
 * The function can be safely removed. Make sure to also remove call to this function when doing so.
 */
function configUpdateAlert(config) {
	if (configUpdateAlert.configUpdateAlertShown) {
		return;
	}

	const isModifiedByUser = (currentValue, forbiddenValue) => {
		if (currentValue === forbiddenValue) {
			return false;
		}

		if (currentValue === undefined) {
			return false;
		}

		return true;
	};

	const valuesToUpdate = [];

	configUpdateAlert.configUpdateAlertShown = true;

	if (!isModifiedByUser(config.licenseKey, '<YOUR_LICENSE_KEY>')) {
		valuesToUpdate.push('LICENSE_KEY');
	}

	if (!isModifiedByUser(config.cloudServices?.tokenUrl, '<YOUR_CLOUD_SERVICES_TOKEN_URL>')) {
		valuesToUpdate.push('CLOUD_SERVICES_TOKEN_URL');
	}

	if (!isModifiedByUser(config.cloudServices?.webSocketUrl, '<YOUR_CLOUD_SERVICES_WEBSOCKET_URL>')) {
		valuesToUpdate.push('CLOUD_SERVICES_WEBSOCKET_URL');
	}

	if (valuesToUpdate.length) {
		window.alert(
			[
				'Please update the following values in your editor config',
				'to receive full access to Premium Features:',
				'',
				...valuesToUpdate.map(value => ` - ${value}`)
			].join('\n')
		);
	}
}
